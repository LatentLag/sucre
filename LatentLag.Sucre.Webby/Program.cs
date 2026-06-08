using System.Net.Mime;
using System.Text;
using LatentLag.Sucre.Duckworth.Service;
using LatentLag.Sucre.Duckworth.Service.Abstraction;
using LatentLag.Sucre.Webby.Handler;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICoffeeHandler, CoffeeHandler>();
builder.Services.AddSingleton<IFibonacciCalculator, FibonacciCalculator>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.BuildCoffeeEndPoint();

app.MapPost("/fibonacci/{sequence}", (int sequence, IFibonacciCalculator fiboCalc) => Results.Text(fiboCalc.CalculateBigInt(sequence).ToString(), MediaTypeNames.Text.Plain, Encoding.UTF8));

app.Run();
