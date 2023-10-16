using MarketPlace.Bussiness.Abstract;
using MarketPlace.Bussiness.Concrete;
using MarketPlace.Bussiness.UnitOfWorks;
using MarketPlace.Common.Helper;
using MarketPlace.Common.HttpContent;
using MarketPlace.DataAccess.Contexts;
using MarketPlace.WebAPI.Mapper;
using MarketPlace.WebAPI.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLocalization(options => options.ResourcesPath = "MarketPlace.Common.Resources");


builder.Services.AddCors(options =>
{
    var cors = builder.Configuration.GetSection("AllowCorsUrl").Get<string[]>();
    options.AddPolicy("_testPolicy", builder =>
    builder
    .WithOrigins(cors)
    .WithMethods("GET", "POST", "OPTIONS")
    .AllowAnyHeader()
    .AllowCredentials()
    .SetPreflightMaxAge(TimeSpan.FromSeconds(500)));

});


builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("tr-TR"),
        // Diğer desteklenen dilleri buraya ekleyin
    };

    options.DefaultRequestCulture = new RequestCulture("tr-TR");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

string connectionType = DatabaseConnectConfiguration.ConnectionString();
string connectionString = builder.Configuration.GetSection("ConnectionStrings")[connectionType]?.ToString() ?? "";
string connectionLogString = builder.Configuration.GetSection("ConnectionLogStrings")[connectionType]?.ToString() ?? "";

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddDbContext<ApplicationLogDbContext>(options =>
    options.UseNpgsql(connectionLogString));

builder.Services.AddAutoMapper(typeof(MyMappingProfile));


// JWT Authentication'ı etkinleştirin
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true, // JWT'nin 'issuer' doğrulamasını yap
        ValidateAudience = true, // JWT'nin 'audience' doğrulamasını yap
        ValidateLifetime = true, // Token süresini doğrula
        ValidateIssuerSigningKey = true, // JWT'nin imza anahtarını doğrula
        ValidIssuer = builder.Configuration["Token:Issuer"], // Güvenilen 'issuer'
        ValidAudience = builder.Configuration["Token:Audience"], // Güvenilen 'audience'
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]?.ToString() ?? "")),
    };
});



builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//Custom depency injection
builder.Services.AddScoped<ILoggerService, LoggerManager>();
builder.Services.AddScoped<IUnitOfWorks, UnitOfWorks>();
builder.Services.AddScoped<IUnitOfWorksLog, UnitOfWorksLog>();

builder.Services.AddScoped<IAccountService, AccountManager>();
builder.Services.AddScoped<IUserAuthorizedLogService, UserAuthorizedLogManager>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IMenuService, MenuManager>();
builder.Services.AddScoped<IRedisService, RedisManager>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("_testPolicy");


CurrentUser.Configure(app.Services.GetRequiredService<IHttpContextAccessor>());


//Hataları kontrol eder.
app.UseErrorHandlingMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
