using System.Numerics;
using LatentLag.Sucre.Duckworth.Service.Abstraction;

namespace LatentLag.Sucre.Duckworth.Service;

public class FibonacciCalculator : IFibonacciCalculator
{
    public long CalculateLong(int sequence)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(sequence, 0);

        long a = 0;
        long b = 1;

        foreach (var _ in Enumerable.Range(0, sequence))
        {
            long hold = b;

            checked { b = b + a; }
            a = hold;
        }

        return a;
    }

    public BigInteger CalculateBigInt(int sequence)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(sequence, 0);

        BigInteger a = BigInteger.Zero;
        BigInteger b = BigInteger.One;

        int i;
        for (i = 0; i < sequence; i++)
        {
            BigInteger hold = b;

            b += a;
            a = hold;

            // If the value is over 64KB of memory we're giving up.
            if (a.GetBitLength() >= ushort.MaxValue * 8)
                throw new ArgumentOutOfRangeException(nameof(sequence), sequence, "Using too much memory, aborting calculation");
        }

        return a;
    }
}
