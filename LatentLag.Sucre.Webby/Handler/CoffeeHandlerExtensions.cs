namespace LatentLag.Sucre.Webby.Handler;

// Integration.BasicTests tests this class
public static class CoffeeHandlerExtensions
{
    public static IServiceCollection RegisterCoffeeHandler(this IServiceCollection sc) =>
        sc.AddSingleton<ICoffeeHandler, CoffeeHandler>();
}
