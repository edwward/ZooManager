using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManager
{
    public static class Output
    {
        public static void ShowInitialInfo()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome to ZOOMANAGER App.");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Please choose (numbers 1 - 7) from options below.");
            Console.ResetColor();
        }

        public static void ShowOptions()
        {
            Console.WriteLine();
            Console.WriteLine("1. Insert animal into zoo");
            Console.WriteLine("2. Update animal in zoo");
            Console.WriteLine("3. Delete animal");
            Console.WriteLine("4. Delete all animals");
            Console.WriteLine("5. Sort animals by Species");
            Console.WriteLine("6. Sort animals by Id");
            Console.WriteLine("7. Exit the app");
        }

        public static void ShowErrorMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Your zoo is empty!");
            Console.ResetColor();
        }
    }
}
