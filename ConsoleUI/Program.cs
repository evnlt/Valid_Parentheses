using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            while (true)
            {
                Console.Write("Enter string: ");
                string input = Console.ReadLine();

                try
                {
                    Console.WriteLine("Result: " + Solution.IsValid(input));
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input");
                    Console.ForegroundColor= ConsoleColor.White;
                }

                Console.WriteLine("\nPress 'y' to restart.");
                if (Console.ReadKey().Key != ConsoleKey.Y)
                    return;
                else
                    Console.Clear();
            }
        }
    }








    public static class Solution
    {
        private static Dictionary<char, char> _brackets = new() { { '(', ')' }, { '{', '}' }, { '[', ']' } };

        // O(n)
        public static bool IsValid(string str)
        {
            if (str == null)
                throw new ArgumentNullException("String is null");

            int len = str.Length;
            if (len <= 1 || len > 1000)
                throw new ArgumentException("Invalid length");
            if (!str.ContainsOnlyParenthesis())
                throw new ArgumentException("Not all characters are parenthesis");

            if (len % 2 == 1)
                return false;

            for (int i = 0; i < len - 1; i += 2)
            {
                foreach (var pair in _brackets)
                {
                    if (str[i] == pair.Key) // is an opening bracket
                    {
                        if (str[i + 1] != pair.Value) // is a closing bracket
                            return false;
                        break;
                    }
                    else if (str[i] == pair.Value) // is a closing bracket
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        private static bool ContainsOnlyParenthesis(this string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (!(_brackets.ContainsKey(str[i]) || _brackets.ContainsValue(str[i])))
                    return false;
            }
            return true;
        }
    }
}