using System.Numerics;

namespace LatentLag.Sucre.Duckworth.Service.Abstraction;

public interface IFibonacciCalculator
{
    long CalculateLong(int sequence);
    BigInteger CalculateBigInt(int sequence);
}
