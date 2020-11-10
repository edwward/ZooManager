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
        public static int GetUserChoice()
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

        public static bool GetInput()
        {
            while (true)
            {
                Console.Write("Do you want to add animal? (y/n) ");
                string input = Console.ReadLine();
                if (input == "y")
                {
                    break;
                }
                else if (input == "n")
                {
                    return true;
                }
                else 
                {
                    Console.WriteLine("Wrong Input!");
                }
            }
            return false;
        }
        private static string InsertAnyText(string message)
        {
            string text = "";
            while (string.IsNullOrWhiteSpace(text))
            {
                Console.Write(message);
                text = Console.ReadLine();
            }
            return text;
        }

        private static string InsertAnyText()
        {
            string text = "";
            while (string.IsNullOrWhiteSpace(text))
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

        public static string InsertSpecies()
        {
            string species = InsertAnyText();
            return species;
        }



        private static int InsertAnyNumber(string message) 
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
        
        public static int InsertWeight(string species, string message)
        {
            int weight = InsertAnyNumber(message);
            return weight;
        }



    }
}
