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
        public List<Animal> zoo { get; set; }

        public Zoo()
        {
            zoo = new List<Animal>();
        }

        public void FromListToZoo(List<Animal> list)
        {

            for (int i = 0; i < list.Count; i++)
            {
                a.Species = list[i].Species;
                a.Weight = list[i].Weight;
                a.Name = list[i].Name;
                zoo.Add(new Animal { Species = a.Species, Weight = a.Weight, Name = a.Name });
            }

        }

        private Animal FindAnimalObject(string animal)
        {
            foreach (Animal item in zoo)
            {
                if (item.Species.Contains(animal))
                    return item;
            }
            return null;
        }

        public void RemoveAnimalObject(string animalToDelete)
        {
            if (FindAnimalObject(animalToDelete) != null)
            {
                zoo.RemoveAll(a => a.Species == animalToDelete);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{animalToDelete} deleted!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{animalToDelete} not found!");
                Console.ResetColor();
            }
        }

        public void AddAnimalObject()
        {
            a.Species = Input.InsertSpecies("Please enter animal species: ");
            a.Name = Input.InsertSpecies("Please enter animal name: ");
            a.Weight = Input.InsertWeight(a.Species, $"Please enter \"{a.Name}\" weight: ");
            zoo.Add(new Animal { Species = a.Species, Name = a.Name, Weight = a.Weight });
        }

        public bool IsListEmpty()
        {
            if (zoo.Count == 0)
            {
                return false;
            }
            return true;
        }

        public void ShowAllAnimals()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Your zoo contains these animals: ");
            Console.ResetColor();
            foreach (Animal a in zoo)
            {
                Console.WriteLine($"{a.Species}, {a.Name}, váží {a.Weight} kg");
            }
        }


        public void SortBySpecies()
        {
            zoo.Sort((x, y) => x.Species.CompareTo(y.Species));
        }

        public void SortByWeight()
        {
            zoo.Sort((x, y) => x.Weight.CompareTo(y.Weight));
        }


    }
}
