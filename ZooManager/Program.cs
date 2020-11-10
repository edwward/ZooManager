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
            if (list != null && list.Count > 0)
            {
                zoo.FromListToZoo(list);
                zoo.ShowAllAnimals();
            }

            while (!isAppRunning)
            {
                int num = Input.GetUserChoice();
                switch (num)
                {
                    case 1:
                        while (!Input.GetInput())
                        {
                            zoo.AddAnimalObject();
                        }
                        zoo.ShowAllAnimals();
                        break;

                    case 2:
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
                        break;

                    case 3:
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

                    case 4:
                        XMLSaveAndRead.SaveZooToXML(zoo);
                        Console.WriteLine("App is over. Press any key to exit.");
                        Console.ReadKey();
                        //isAppRunning = true;
                        return;
                }
              
            }

            Console.ReadKey();
        }
    }
}
