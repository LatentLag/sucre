using LatentLag.Sucre.Webby.Handler;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICoffeeHandler, CoffeeHandler>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.BuildCoffeeEndPoint();

app.Run();
