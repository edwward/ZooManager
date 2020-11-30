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
            List<Animal> list = new List<Animal>();
            Zoo zoo = new Zoo(list);

            list = XMLSaveAndRead.LoadZooFromXML();
            if (list != null && list.Count > 0)
            {
                zoo.FromListToZoo(list);
                zoo.ShowAllAnimals();
            }

            while (!isAppRunning)
            {
                int num = Input.GetChoiceNumber();
                switch (num)
                {
                    case 1:
                        while (!Input.GetInput("Do you want to add animal? (y/n) "))
                        {
                            zoo.AddAnimalObject();
                        }
                        if (zoo.IsListEmpty())
                        {
                            zoo.ShowAllAnimals();
                        }
                        else 
                        {
                            Output.ShowErrorMessage();
                        }
                        break;

                    case 2:
                        if (zoo.IsListEmpty())
                        {
                            int input2 = Input.InsertAnyNumber("Type the animal Id you want to update: ");
                            zoo.UpdateAnimalObject(input2);
                            zoo.ShowAllAnimals();
                        }
                        else 
                        {
                            Output.ShowErrorMessage();
                        }
                        break;

                    case 3:
                        if (zoo.IsListEmpty())
                        {
                            int input = Input.InsertAnyNumber("Type the animal Id you want to delete: ");
                            zoo.RemoveAnimalObjectById(input);
                            zoo.ShowAllAnimals();
                        }
                        else
                        {
                            Output.ShowErrorMessage();
                        }
                        break;

                    case 4:
                        zoo.RemoveAllAnimals();
                        break;

                    case 5:
                        if (zoo.IsListEmpty())
                        {
                            zoo.SortBySpecies();
                            zoo.ShowAllAnimals();
                        }
                        else
                        {
                            Output.ShowErrorMessage();
                        }
                        break;

                    case 6:
                        if (zoo.IsListEmpty())
                        {
                            zoo.SortById();
                            zoo.ShowAllAnimals();
                        }
                        else
                        {
                            Output.ShowErrorMessage();
                        }
                        break;

                     case 7:
                        zoo.SortById();
                        XMLSaveAndRead.SaveZooToXML(zoo);
                        Console.WriteLine("App is over. Press any key to exit.");
                        Console.ReadKey();
                        return;
                }
            }
            Console.ReadKey();
        }
    }
}
