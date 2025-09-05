using NLog.Web;
using Npgsql;
using TreeApi.Middlewares;
using TreeLogic;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var dataSource = new NpgsqlDataSourceBuilder(connectionString).Build();

builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);

builder.Host.UseNLog();

builder.Services.AddLogic(dataSource);
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();
app.UseErrorHandlingMiddleware();

app.Services.ConfigureLogic();

app.MapControllers();

app.Run();