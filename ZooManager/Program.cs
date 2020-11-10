using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZooManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Output.ShowInitialInfo();
            bool isAppRunning = false;
            Zoo zoo = new Zoo();

            List<Animal> list = XMLSaveAndRead.LoadZooFromXML();
            if (list != null)
            {
                zoo.FromListToZoo(list);
            }

            //zoo.ShowAllAnimals();
            //foreach (animal a in zoo)
            //{
            //    console.writeline("{0}, {1} kg", a.species, a.weight);
            //}
            //Zoo zoo = XMLSaveAndRead.LoadZooFromXML();

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
                    XMLSaveAndRead.SaveZooToXML(zoo);
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
