using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ZooManager
{
    public class Zoo
    {
        Animal a = new Animal();
        public List<Animal> ZooList { get; set; }
        int id;

        public Zoo()        
        {
            
            ZooList = XMLSaveAndRead.LoadZooFromXML();
            if (ZooList != null && ZooList.Count > 0)
            {
                id = ZooList[ZooList.Count - 1].Id + 1;
            }
            else 
            {
                ZooList = new List<Animal>();
                id = 1;
            }

        }

        public void FindAnimalObject()
        {
            if (IsListEmpty())
            {
                string text = Input.InsertAnyText("Type the animal species you want to find: ");
                var query = from animal in ZooList where (animal.Species.StartsWith(text, StringComparison.OrdinalIgnoreCase)) select animal;
                if (query.Count() > 0)
                {
                    Output.FormatTextBlue("   I found these animals: ");
                    Console.ResetColor();
                    Output.FormatTableHeader();
                    foreach (var a in query)
                    {
                        Console.WriteLine("{0, 4} | {1, -18} | {2, -18} | {3, 4} kg", a.Id, a.Species, a.Name, a.Weight);
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Animal \"{text}\" not found!");
                    Console.ResetColor();
                }
            }
            else
            {
                Output.ShowErrorMessage();
            }
        }

        public void RemoveAnimalObjectById() 
        {
            if (IsListEmpty())
            {
                int idToDelete = Input.InsertAnyNumber("Type the animal Id you want to delete: ");
                if (idToDelete != 0 && idToDelete < id && ZooList.Any(a => a.Id == idToDelete))
                {
                    ZooList.RemoveAll(a => a.Id == idToDelete);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Animal with Id {idToDelete} removed.");
                    Console.ResetColor();
                    if (IsListEmpty())
                    {
                        ShowAllAnimals();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Animal Id {idToDelete} not found!");
                    Console.ResetColor();
                    ShowAllAnimals();
                }
            }
            else
            {
                Output.ShowErrorMessage();
            }

        }

        public void RemoveAllAnimals()
        {
            if (IsListEmpty())
            {
                ZooList.Clear();
                id = 1;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("All animals were removed. Your zoo is empty.");
                Console.ResetColor();
            }
            else
            {
                Output.ShowErrorMessage();
            }

        }

        public void AddAnimalObject()
        {
            if (ZooList != null && ZooList.Count > 0)
            {
                id = ZooList[ZooList.Count - 1].Id + 1;
            }

            while (!Input.GetInput("Do you want to add animal? (y/n) "))
            {
                a.Id = id;
                a.Species = Input.InsertSpecies("Please enter animal species: ");
                a.Name = Input.InsertSpecies(a.Species, $"Please enter \"{a.Species}\" name: ");
                a.Weight = Input.InsertWeight(a.Species, $"Please enter \"{a.Name}\" weight: ");
                if (ZooList != null)
                {
                    ZooList.Add(new Animal { Id = a.Id, Species = a.Species, Name = a.Name, Weight = a.Weight });
                }
                id++;
            }
            if (ZooList != null && ZooList.Count > 0)
            {
                ShowAllAnimals();
            }

        }

        public void UpdateAnimalObject()  
        {
            if (IsListEmpty())
            {
                int idToUpdate = Input.InsertAnyNumber("Type the animal Id you want to update: ");

                if (idToUpdate != 0 && idToUpdate < id && ZooList.Any(a => a.Id == idToUpdate))
                {
                    Output.UpdateAnimalOptions();
                    int number = Input.InsertAnyPositiveNumberRange();

                    if (number == 1)
                    {
                        ZooList.Find(a => a.Id == idToUpdate).Species = Input.InsertSpecies("Please enter updated species: ");
                    }
                    else if (number == 2)
                    {
                        ZooList.Find(a => a.Id == idToUpdate).Name = Input.InsertSpecies("Please enter updated animal name: ");
                    }
                    else if (number == 3)
                    {
                        ZooList.Find(a => a.Id == idToUpdate).Weight = Input.InsertWeight(a.Species, "Please enter updated animal weight: ");
                    }
                    else
                    {
                        ShowAllAnimals();
                        return;
                    }
                    ShowAllAnimals();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Animal Id {idToUpdate} not found!");
                    Console.ResetColor();
                }
            }
            else
            {
                Output.ShowErrorMessage();
            }
        }

        private bool IsListEmpty()
        {
            if (ZooList != null && ZooList.Count == 0)
            {
                return false;
            }
            return true;
        }

        public void ShowAllAnimals()
        {
            if (IsListEmpty())
            {
                Console.WriteLine();
                Output.FormatTextBlue("   Your zoo contains these animals: ");
                Console.ResetColor();
                Output.FormatTableHeader();
                foreach (Animal a in ZooList)
                {
                    Console.WriteLine("{0, 4} | {1, -18} | {2, -18} | {3, 4} kg", a.Id, a.Species, a.Name, a.Weight);
                }
                Console.WriteLine();
            }
        }

        public void SortBySpecies()
        {
            if (IsListEmpty())
            {
                ZooList.Sort((x, y) => x.Species.CompareTo(y.Species));
                ShowAllAnimals();
            }
            else
            {
                Output.ShowErrorMessage();
            }
        }

        public void SortByWeight()
        {
            if (IsListEmpty())
            {
                ZooList.Sort((y, x) => x.Weight.CompareTo(y.Weight));
                ShowAllAnimals();
            }
            else
            {
                Output.ShowErrorMessage();
            }
        }

        public void SortById()
        {
            if (IsListEmpty())
            {
                ZooList.Sort((x, y) => x.Id.CompareTo(y.Id));
                ShowAllAnimals();
            }
            else
            {
                Output.ShowErrorMessage();
            }
        }

        public void SortByIdNotShowingAnyDetails()
        {
            if (IsListEmpty() && ZooList != null && ZooList.Count > 0)
            {
                ZooList.Sort((x, y) => x.Id.CompareTo(y.Id));
            }
        }
    }
}
