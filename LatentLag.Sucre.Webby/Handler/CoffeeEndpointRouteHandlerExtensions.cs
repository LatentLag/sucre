namespace LatentLag.Sucre.Webby.Handler;

// Integration.BasicTests tests this class
public static class CoffeeEndpointRouteHandlerExtensions
{
    public static RouteHandlerBuilder BuildCoffeeEndPoint(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapMethods("/coffee", ["POST", "BREW"], (ICoffeeHandler teapotHandler) => teapotHandler.PostCoffee());
}
