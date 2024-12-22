/*public class Program
{
    public static void Main()
    {
        var t = Int32.Parse(Console.ReadLine());
        var primeLst = new List<long>();

        for (var i = 0; i < t; i++)
        {


            for(var j = m; j <= n; j++)
            {
                var divCounter = 0;
                var divider = 2;

                while (divider < j-1)
                {
                    if (j % divider != 0)
                    {
                        divider++;
                        continue;
                    }

                    divCounter++;
                    break;
                }
                
                if (divCounter == 0 && j != 1) primeLst.Add(j);
            }
        }

        foreach (var prime in primeLst)
        {
            Console.WriteLine(prime);
        }
    }
}*/

// C# program to print prime numbers from 1 to N
// using Sieve of Eratosthenes
using System;

// public class GFG { // Function to find prime numbers from 1
//     // to N
//     
//     static public void sieve_of_eratosthenes(long n, long m)
//     {
//         
//         // Create a boolean array "is_prime[0..n]" and
//         // initialize all entries as true. A value in
//         // is_prime[i] will finally be false if i is Not a
//         // prime, else true
//         bool[] is_prime = new bool[n + 1];
//         Array.Fill(is_prime, true);
//
//         // Mark 0 and 1 as false as they are not prime
//         is_prime[0] = is_prime[1] = false;
//
//         // Traverse through all numbers starting from 2, as
//         // 1 is not prime
//         for (var p = 2; p * p <= n; p++) {
//             // If is_prime[p] is not changed, then it is a
//             // prime
//             if (is_prime[p]) {
//                 // Update all multiples of p as not prime
//                 for (var i = p * p; i <= n; i += p) {
//                     is_prime[i] = false;
//                 }
//             }
//         }
//
//         // Print all prime numbers
//         for (int i = 2; i <= n; i++) {
//             if (is_prime[i]) {
//                 Console.Write(i + " ");
//             }
//         }
//     }

UNDONE!!! 
    
public class Program
{
    public static void Main()
    {
        // Call sieve_of_eratosthenes() function with value
        // 100

        var t = Int32.Parse(Console.ReadLine());
        
        for (var ti = 0; ti < t; ti++)
        {
            string input = Console.ReadLine();
            string[] s = input.Split();
            var m = long.Parse(s[0]);
            var n = long.Parse(s[1]);

            bool[] is_prime = new bool[n + 1];
            Array.Fill(is_prime, true);
            
            

            // Mark 0 and 1 as false as they are not prime
            is_prime[0] = is_prime[1] = false;

            // Traverse through all numbers starting from 2, as
            // 1 is not prime
            for (var p = 2; p * p <= n; p++)
            {
                // If is_prime[p] is not changed, then it is a
                // prime
                if (is_prime[p])
                {
                    // Update all multiples of p as not prime
                    for (var i = p * p; i <= n; i += p)
                    {
                        is_prime[i] = false;
                    }
                }
            }

            // Print all prime numbers
            for (var i = m; i <= n; i++)
            {
                if (is_prime[i])
                {
                    Console.WriteLine(i);
                }
                
            }
            
            Console.WriteLine();
        }
    }
}