using System.Numerics;
using LatentLag.Sucre.Duckworth.Service;

namespace LatentLag.Sucre.Duckworth.Test.Service.Implementation;

[TestCategory("Fibonacci")]
[TestClass]
public class FibonacciCalculatorTest
{
    [DataRow(20, 6765L)]
    [DataRow(4, 3L)]
    [DataRow(3, 2L)]
    [DataRow(2, 1L)]
    [DataRow(1, 1L)]
    [DataRow(0, 0L)]
    [TestMethod]
    public void TestFibonacci(int sequence, long expected)
    {
        FibonacciCalculator fibonacci = new();

        long actual = fibonacci.CalculateLong(sequence);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void CalculateLong_Negative_Sequence()
    {
        FibonacciCalculator fibonacciMaker = new();

        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => fibonacciMaker.CalculateLong(-1));
    }

    [TestMethod]
    public void CalculateLong_Sequence_TooLarge()
    {
        FibonacciCalculator fibonacciMaker = new();

        Assert.ThrowsExactly<OverflowException>(() => fibonacciMaker.CalculateLong(92));
    }

    [DataRow(20, 6765L)]
    [DataRow(4, 3L)]
    [DataRow(3, 2L)]
    [DataRow(2, 1L)]
    [DataRow(1, 1L)]
    [DataRow(0, 0L)]
    [TestMethod]
    public void TestFibonacciBigInt(int sequence, long expected)
    {
        FibonacciCalculator fibonacciMaker = new();

        BigInteger actual = fibonacciMaker.CalculateBigInt(sequence);

        Assert.AreEqual(new BigInteger(expected), actual);
    }

    [TestMethod]
    public void TestFibonacciBigInt_Negative_Sequence()
    {
        FibonacciCalculator fibonacciMaker = new();

        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => fibonacciMaker.CalculateBigInt(-1));
    }

    [TestMethod]
    public void CalculateBigInt_Sequence_TooLarge()
    {
        FibonacciCalculator fibonacciMaker = new();

        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => fibonacciMaker.CalculateBigInt(755_184));
    }
}
