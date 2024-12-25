using System.Numerics;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] s = Console.ReadLine().Split();

            Console.WriteLine(BigInteger.Parse(s[0]) * BigInteger.Parse(s[1]));
        }
    }
}