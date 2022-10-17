using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public static class Solution
    {
        private static Dictionary<char, char> _brackets = new() { { '(', ')' }, { '{', '}' }, { '[', ']' } };

        // O(n) despite there being 2 (not nested) for loops

        public static bool IsValid(string str)
        {
            // validation
            if (str == null)
                throw new NullReferenceException();

            int len = str.Length;
            if (len <= 1 || len > 1000)
                throw new ArgumentException("Invalid length");
            if (!str.ContainsOnlyParenthesis())
                throw new ArgumentException("Not all characters are parenthesis");

            // algorithm
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

        // ()([])
        public static bool IsValid_UsingStack(string str)
        {
            // validation
            if (str == null)
                throw new NullReferenceException();

            int len = str.Length;
            if (len <= 1 || len > 1000)
                throw new ArgumentException("Invalid length");
            if (!str.ContainsOnlyParenthesis())
                throw new ArgumentException("Not all characters are parenthesis");

            // algorithm
            if (len % 2 == 1)
                return false;

            Stack<char> stack = new();
            foreach (char c in str)
            {
                if (_brackets.ContainsKey(c))
                    stack.Push(c);
                else if (stack.Any())
                {
                    if (c != _brackets[stack.Pop()])
                        return false;
                }
                else
                    return false;
            }
            return !stack.Any();
        }
        private static bool ContainsOnlyParenthesis(this string str)
        {
            foreach (char c in str)
            {
                if (!(_brackets.ContainsKey(c) || _brackets.ContainsValue(c)))
                    return false;
            }
            return true;
        }
    }
}
