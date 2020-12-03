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
            Console.WindowHeight = 35;
            Console.WriteLine();
            string title = @"
  _______   ___  _ __ ___   __ _ _ __   __ _  __ _  ___ _ __  
 |_  / _ \ / _ \| '_ ` _ \ / _` | '_ \ / _` |/ _` |/ _ \ '__| 
  / / (_) | (_) | | | | | | (_| | | | | (_| | (_| |  __/ |    
 /___\___/ \___/|_| |_| |_|\__,_|_| |_|\__,_|\__, |\___|_|    
                                              __/ |           
                                             |___/            ";
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("   Welcome to ZOOMANAGER App.");
            Console.ResetColor();
            Console.WriteLine(title);
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Please choose (numbers 1 - 9) from options below.");
            Console.ResetColor();
        }

        public static void ShowOptions()
        {
            Console.WriteLine();
            Console.WriteLine("1. Insert animal into zoo");
            Console.WriteLine("2. Update animal in zoo");
            Console.WriteLine("3. Find animal in zoo");
            Console.WriteLine("4. Delete animal");
            Console.WriteLine("5. Delete all animals");
            Console.WriteLine("6. Sort animals by Species");
            Console.WriteLine("7. Sort animals by Id");
            Console.WriteLine("8. Sort animals by Weight");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-----------------------------");
            Console.ResetColor();
            Console.WriteLine("9. Save zoo and exit the app");
            
        }

        public static void UpdateAnimalOptions()
        {
            Console.WriteLine();
            Console.WriteLine("   1. Update animal species");
            Console.WriteLine("   2. Update animal name");
            Console.WriteLine("   3. Update animal weight");
            Console.WriteLine("   4. Get me out of here");
        }

        public static void ShowErrorMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Your zoo is empty!");
            Console.ResetColor();
        }

        public static void FormatTableHeader()
        {
            Console.WriteLine();
            Console.WriteLine("  Id | Species            | Name               |  Weight");
            Console.WriteLine(" --------------------------------------------------------");
        }

        public static void FormatTextBlue(string text)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(text);
        }


    }
}
