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
                Console.Write("Enter a string: ");
                string input = Console.ReadLine();

                try
                {
                    Console.WriteLine("Result: " + Solution.IsValid(input));
                }
                catch (ArgumentException)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Invalid input");
                    Console.ForegroundColor= ConsoleColor.White;
                }
                catch (Exception) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("An error has occured");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine("\nPress 'y' to restart.");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                    Console.Clear();
                else
                    return;
            }
        }
    }
}