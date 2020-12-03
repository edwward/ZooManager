using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZooManager
{
    public static class Input
    {
        public static int GetChoiceNumber()
        {
            int num = 0;
            bool isNum = false;

            while (!isNum)
            {
                Output.ShowOptions();
                isNum = int.TryParse(Console.ReadLine(), out num);
            }
            return num;
        }

        public static bool GetInput(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if (input.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                else if (input.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong Input!");
                    Console.ResetColor();
                }
            }
            return false;
        }

        public static string InsertAnyText(string message)
        {
            string text = "";
            while (string.IsNullOrWhiteSpace(text) || text.Any(char.IsDigit))
            {
                Console.Write(message);
                text = Console.ReadLine();
            }
            return text;
        }

        private static string InsertAnyText()
        {
            string text = "";
            while (string.IsNullOrWhiteSpace(text) || text.Any(char.IsDigit))
            {
                text = Console.ReadLine();
            }
            return text;
        }

        public static string InsertSpecies(string message)
        {
            string species = InsertAnyText(message);
            return species;
        }

        public static string InsertSpecies(string text, string message)
        {
            string species = InsertAnyText(message);
            return species;
        }

        public static int InsertAnyNumber(string message)
        {
            string input = "";
            bool isNum = false;
            int number = 0;
            while (string.IsNullOrWhiteSpace(input) && !isNum)
            {
                Console.Write(message);
                isNum = int.TryParse(Console.ReadLine(), out number);
            }
            return number;
        }

        private static int InsertAnyNumber()
        {
            string input = "";
            bool isNum = false;
            int number = 0;
            while (string.IsNullOrWhiteSpace(input) && !isNum)
            {
                isNum = int.TryParse(Console.ReadLine(), out number);
            }
            return number;
        }

        public static int InsertAnyPositiveNumber(string message)
        {
            int number = 0;
            while (number <= 0)
            {
                number = InsertAnyNumber(message);
            }
            return number;
        }

        public static int InsertAnyPositiveNumberRange()
        {
            int number = 0;
            while (number <= 0 && number < 4)
            {
                number = InsertAnyNumber();
            }
            return number;
        }


        public static int InsertWeight(string species, string message)
        {
            int weight = InsertAnyPositiveNumber(message);
            return weight;
        }
    }
}
