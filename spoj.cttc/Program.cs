using System;
using System.Collections.Generic;
// 
public class Program
{
    const int S = 1 << 10;

    public static void Main(string[] args)
    {
        int T, N;
        int[] order = new int[S];
        int[] was = new int[S], children = new int[S];

        T = int.Parse(Console.ReadLine());
        for (int c = 0; c < T; c++)
        {
            N = int.Parse(Console.ReadLine());
            string[] orderInput = Console.ReadLine().Split();
            for (int i = 1; i <= N + N; i++)
            {
                order[i] = int.Parse(orderInput[i - 1]);
            }

            for (int i = 1; i <= N; i++)
            {
                children[i] = 0;
                was[i] = 0;
            }

            Stack<int> open = new Stack<int>();
            for (int i = 1; i <= N + N; i++)
            {
                if (was[order[i]] == 0)
                {
                    if (open.Count > 0)
                    {
                        children[open.Peek()]++;
                    }
                    was[order[i]] = 1;
                    open.Push(order[i]);
                }
                else
                {
                    open.Pop();
                }
            }

            Console.WriteLine("Case " + (c + 1) + ":");
            for (int i = 1; i <= N; i++)
            {
                Console.WriteLine(i + " -> " + children[i]);
            }
            if (c < T - 1)
            {
                Console.WriteLine();
            }
        }
    }
}