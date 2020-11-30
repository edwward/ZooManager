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
        private Animal a = new Animal();
        public List<Animal> ZooList { get; set; }

        public int id = 1;

        public Zoo(List<Animal> zoolist)
        {
            ZooList = zoolist;
        }

        public Zoo()
        {
        }

        public void FromListToZoo(List<Animal> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                a.Id = list[i].Id;
                a.Species = list[i].Species;
                a.Weight = list[i].Weight;
                a.Name = list[i].Name;
                ZooList.Add(new Animal { Id = a.Id, Species = a.Species, Weight = a.Weight, Name = a.Name });
                a.Id++;
            }
            id = a.Id;
        }

        public void RemoveAnimalObjectById(int idToDelete)
        {
            if (idToDelete != 0 && idToDelete < id)
            {
                ZooList.RemoveAll(a => a.Id == idToDelete);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Animal with Id {idToDelete} removed.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Animal Id {idToDelete} not found!");
                Console.ResetColor();
            }
        }

        public void RemoveAllAnimals()
        {
            ZooList.Clear();
            id = 1;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("All animals were removed. Your zoo is empty.");
            Console.ResetColor();
        }

        public void AddAnimalObject()
        {
            a.Id = id;
            a.Species = Input.InsertSpecies("Please enter animal species: ");
            a.Name = Input.InsertSpecies("Please enter animal name: ");
            a.Weight = Input.InsertWeight(a.Species, $"Please enter \"{a.Name}\" weight: ");
            ZooList.Add(new Animal { Id = a.Id, Species = a.Species, Name = a.Name, Weight = a.Weight });
            id++;
        }

        public void UpdateAnimalObject(int idToUpdate)
        {
            if (idToUpdate != 0 && idToUpdate < id)
            {
                ZooList.Find(a => a.Id == idToUpdate).Species = Input.InsertSpecies("Please enter updated animal species: ");
                ZooList.Find(a => a.Id == idToUpdate).Name = Input.InsertSpecies("Please enter updated animal name: ");
                ZooList.Find(a => a.Id == idToUpdate).Weight = Input.InsertWeight(a.Species, "Please enter updated animal weight: ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Animal Id {idToUpdate} not found!");
                Console.ResetColor();
            }
        }

        public bool IsListEmpty()
        {
            if (ZooList.Count == 0)
            {
                return false;
            }
            return true;
        }

        public void ShowAllAnimals()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("    Your zoo contains these animals: ");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("  Id | Species            | Name               |  Weight");
            Console.WriteLine(" --------------------------------------------------------");
            foreach (Animal a in ZooList)
            {
                Console.WriteLine("{0, 4} | {1, -18} | {2, -18} | {3, 4} kg", a.Id, a.Species, a.Name, a.Weight);
            }
        }

        public void SortBySpecies()
        {
            ZooList.Sort((x, y) => x.Species.CompareTo(y.Species));
        }

        public void SortByWeight()
        {
            ZooList.Sort((x, y) => x.Weight.CompareTo(y.Weight));
        }

        public void SortById()
        {
            ZooList.Sort((x, y) => x.Id.CompareTo(y.Id));
        }


    }
}
