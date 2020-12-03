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
            zoo.ShowAllAnimals();

            while (!isAppRunning)
            {
                int num = Input.GetChoiceNumber();
                switch (num)
                {
                    case 1:
                        zoo.AddAnimalObject();
                        break;

                    case 2:
                        zoo.UpdateAnimalObject();
                        XMLSaveAndRead.SaveZooToXML(zoo);
                        break;

                    case 3:
                        zoo.FindAnimalObject();
                        break;

                    case 4:
                        zoo.RemoveAnimalObjectById();
                        XMLSaveAndRead.SaveZooToXML(zoo);
                        break;

                    case 5:
                        zoo.RemoveAllAnimals();
                        XMLSaveAndRead.SaveZooToXML(zoo);
                        break;

                    case 6:
                        zoo.SortBySpecies();
                        break;

                    case 7:
                        zoo.SortById();
                        break;

                    case 8:
                        zoo.SortByWeight();
                        break;

                    case 9:
                        zoo.SortByIdNotShowingAnyDetails();
                        XMLSaveAndRead.SaveZooToXML(zoo);
                        Output.FormatTextBlue("App is over. Press any key to exit.");
                        Console.ReadKey();
                        return;
                }
            }
            //Console.ReadKey();
        }
    }
}
