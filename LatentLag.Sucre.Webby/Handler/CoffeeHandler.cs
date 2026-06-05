using System.Text;

namespace LatentLag.Sucre.Webby.Handler;

// Integration.BasicTests tests this class
public class CoffeeHandler: ICoffeeHandler
{
    public IResult PostCoffee() =>
        Results.Text("I'm a teapot", "text/plain", Encoding.UTF8, 418);
}
