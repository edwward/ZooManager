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
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome to ZOOMANAGER App.");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Please choose (numbers 1 - 4) from options below.");
            
        }

        public static void ShowErrorMessage() 
        {
            Console.WriteLine("Your zoo is empty!");
        }
     }
}
