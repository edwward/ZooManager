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
                Console.WriteLine();
                Console.WriteLine("1. Insert animal into zoo");
                Console.WriteLine("2. Delete animal");
                Console.WriteLine("3. Sort animals alphabetically");
                Console.WriteLine("4. Exit the app");
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

        public static string InsertSpecies()
        {
            string species = "";
            while (string.IsNullOrWhiteSpace(species))
            {
                Console.Write("Please enter animal species: ");
                species = Console.ReadLine();
            }
            return species;
        }

        public static int InsertWeight(string species)
        {
            string input = "";
            bool isNum = false;
            int weight = 0;
            while (string.IsNullOrWhiteSpace(input) && !isNum)
            {
                Console.Write($"Please enter \"{species}\" weight: ");
                isNum = int.TryParse(Console.ReadLine(), out weight);
            }
            return weight;
        }



    }
}
