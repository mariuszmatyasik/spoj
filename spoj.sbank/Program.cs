using System;
using System.Collections.Generic;
using System.Linq;

class bank
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for (int testCase = 0; testCase < t; testCase++)
        {
            int n = int.Parse(Console.ReadLine());
            var accounts = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string account = Console.ReadLine().Trim();
                if (accounts.ContainsKey(account))
                {
                    accounts[account]++;
                }
                else
                {
                    accounts[account] = 1;
                }
            }

            var sortedAccounts = accounts.Keys.ToList();
            sortedAccounts.Sort();

            foreach (var account in sortedAccounts)
            {
                Console.WriteLine($"{account} {accounts[account]}");
            }

            if (testCase < t - 1)
            {
                Console.WriteLine();
                Console.ReadLine(); // read the empty line between test cases
            }
        }
    }
}