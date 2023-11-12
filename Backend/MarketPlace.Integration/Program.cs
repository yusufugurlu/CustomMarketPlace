using Hangfire;
using Hangfire.PostgreSql;
using MarketPlace.Bussiness.UnitOfWorks;
using MarketPlace.Common.Helper;
using MarketPlace.DataAccess.Contexts;
using MarketPlace.Queue.Abstract;
using MarketPlace.Queue.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionType = DatabaseConnectConfiguration.ConnectionString();
string connectionLogString = builder.Configuration.GetSection("ConnectionLogStrings")[connectionType]?.ToString() ?? "";

builder.Services.AddDbContext<ApplicationLogDbContext>(options =>
    options.UseNpgsql(connectionLogString));


builder.Services.AddHangfire(x => x
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UsePostgreSqlStorage(connectionLogString, new PostgreSqlStorageOptions
        {
            QueuePollInterval = TimeSpan.FromSeconds(15),
            UseNativeDatabaseTransactions = true
        }));

builder.Services.AddHangfireServer();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//Custom depency injection
builder.Services.AddScoped<IUnitOfWorksLog, UnitOfWorksLog>();
builder.Services.AddScoped<IQueueService, QueueManager>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHangfireDashboard("/system/task");
app.UseHangfireServer();

var serviceProvider = builder.Services.BuildServiceProvider();
var hizmetTuru = serviceProvider.GetRequiredService<IQueueService>().GetType();

var hizmet = ActivatorUtilities.CreateInstance(serviceProvider, hizmetTuru) as IQueueService;

RecurringJob.AddOrUpdate(() => hizmet.RunQueueAsync(), Cron.Minutely());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
