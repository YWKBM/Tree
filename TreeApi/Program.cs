using Npgsql;
using TreeApi.Middlewares;
using TreeLogic;

var builder = WebApplication.CreateBuilder(args);
var dataSource = new NpgsqlDataSourceBuilder("Host=localhost;Port=5432;Database=Tree;Username=postgres;Password=123456").Build();

builder.Services.AddLogic(dataSource);
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();
app.UseErrorHandlingMiddleware();

app.Services.ConfigureLogic();

app.MapControllers();

app.Run();