using Hangfire;
using Hangfire.PostgreSql;
using MarketPlace.Bussiness.UnitOfWorks;
using MarketPlace.Common.Helper;
using MarketPlace.DataAccess.Contexts;
using MarketPlace.Queue.Abstract;
using MarketPlace.Queue.Concrete;
using MarketPlace.WorkIntegration.Trendyol.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using System;
using System.Xml.Linq;

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
builder.Services.AddHttpClient();
builder.Services.AddSingleton<ITrendyolService, TrendyolManager>();

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
var providerType = serviceProvider.GetRequiredService<IQueueService>().GetType();

var provider = ActivatorUtilities.CreateInstance(serviceProvider, providerType) as IQueueService;

var trendyol = serviceProvider.GetRequiredService<ITrendyolService>().GetType();

var trendyol1 = ActivatorUtilities.CreateInstance(serviceProvider, trendyol) as ITrendyolService;

//Bu bir örnektir.
await trendyol1.GetCategoryTree(new MarketPlace.DataTransfer.Dtos.Integrations.IntegrationSignInDto()
{
    AppKey = "8o4dJoNeoxHeL7WSlR3P",
    AppSecret = "gUsualtIHQNW2a8yD7ig",
    CustomKey = "251427",
});

RecurringJob.AddOrUpdate(() => provider.RunQueueAsync(), Cron.MinuteInterval(5));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
