using TreeLogic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogic();
var app = builder.Build();

app.Services.ConfigureLogic();

app.MapGet("/", () => "Hello World!");


app.Run();