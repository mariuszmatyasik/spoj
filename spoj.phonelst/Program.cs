using System;
using System.Collections.Generic;

class Program
{
    // Trie Node class
    class TrieNode
    {
        public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
        public bool IsEndOfNumber = false;
    }

    // Trie class
    class Trie
    {
        private TrieNode root;

        public Trie()
        {
            root = new TrieNode();
        }

        public bool Insert(string number)
        {
            TrieNode current = root;
            foreach (char digit in number)
            {
                if (!current.Children.ContainsKey(digit))
                {
                    current.Children[digit] = new TrieNode();
                }
                current = current.Children[digit];

                if (current.IsEndOfNumber)
                {
                    return false;
                }
            }
            
            if (current.Children.Count > 0)
            {
                return false;
            }

            current.IsEndOfNumber = true;
            return true;
        }
    }

    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> phoneNumbers = new List<string>();

            for (int j = 0; j < n; j++)
            {
                phoneNumbers.Add(Console.ReadLine().Trim());
            }

            Console.WriteLine(IsConsistent(phoneNumbers) ? "YES" : "NO");
        }
    }

    static bool IsConsistent(List<string> phoneNumbers)
    {
        Trie trie = new Trie();
        foreach (var number in phoneNumbers)
        {
            if (!trie.Insert(number))
            {
                return false;
            }
        }
        return true;
    }
}
