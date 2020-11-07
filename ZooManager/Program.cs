using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Output.ShowInitialInfo();
            bool isAppRunning = false;

            Zoo zoo = new Zoo();
           
            while (!isAppRunning) 
            {
                int num = Input.GetUserChoice();

                if (num == 1)
                {
                    while (!Input.GetInput())
                    {
                        zoo.AddAnimalObject();
                    }
                    zoo.ShowAllAnimals();
                }

                if (num == 2)
                {
                    if (zoo.IsListEmpty())
                    {
                        Console.Write("Type the animal species you want to delete: ");
                        string input = Console.ReadLine();
                        zoo.RemoveAnimalObject(input);
                        zoo.ShowAllAnimals();
                    }
                    else 
                    {
                        Output.ShowErrorMessage();
                    }
                    
                }

                if (num == 3)
                {
                    if (zoo.IsListEmpty())
                    {
                        zoo.SortByName();
                        zoo.ShowAllAnimals();
                    }
                    else 
                    {
                        Output.ShowErrorMessage();
                    }
                    
                }

                if (num == 4)
                {
                    Console.WriteLine("App is over. Press any key to exit.");
                    Console.ReadKey();
                    isAppRunning = true;
                    return;
                }

            }
            
            Console.ReadKey();
        }
    }
}
