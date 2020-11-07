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
            
            List<Animal> zoo = new List<Animal>();

            while (!isAppRunning) 
            {
                int num = Input.GetUserChoice();

                if (num == 1)
                {
                    while (!Input.GetInput())
                    {
                        ListMethods listMethods = new ListMethods();
                        listMethods.AddAnimalObject(zoo);
                    }
                    Output.ShowAllAnimals(zoo);
                }

                if (num == 2)
                {
                    if (ListMethods.IsListEmpty(zoo))
                    {
                        Console.Write("Type the animal species you want to delete: ");
                        string input = Console.ReadLine();
                        ListMethods.RemoveAnimalObject(input, zoo);
                        Output.ShowAllAnimals(zoo);
                    }
                    else 
                    {
                        Output.ShowErrorMessage();
                    }
                    
                }

                if (num == 3)
                {
                    if (ListMethods.IsListEmpty(zoo))
                    {
                        ListMethods.SortByName(zoo);
                        Output.ShowAllAnimals(zoo);
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
