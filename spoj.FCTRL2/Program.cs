using System.Numerics;

public class Program
{
    static BigInteger Factorial(BigInteger n)
    {
        if (n <= 1) return 1;
        return n * Factorial(n - 1);
    }
    public static void Main()
    {
        int t = Int32.Parse(Console.ReadLine());

        for (var i = 0; i < t; i++)
        {
            var n = Int32.Parse(Console.ReadLine());

            Console.WriteLine(Factorial(n));
        }
    }
}