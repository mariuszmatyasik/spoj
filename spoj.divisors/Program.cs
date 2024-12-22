using System;

public class Program
{
    public static void Main()
    {
        
        var t = Int32.Parse(Console.ReadLine());


        for (int j = 0; j < t; j++)
        {
            var n = Int32.Parse(Console.ReadLine());
            var sum = 0;
            for (var i = 1; i <= Math.Sqrt(n); i++)
            {
                
                if (n % i == 0)
                {
                    sum += i;
                    if (i != n / i)
                    {
                        sum += n / i;
                    }
                }
    
            }

            Console.WriteLine(sum - n);
        }


    }
}
