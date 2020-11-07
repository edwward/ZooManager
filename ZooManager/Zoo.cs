using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.WriteLine("Animal deleted!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Animal not found!");
                Console.ResetColor();
            }

        }

        public void AddAnimalObject()
        {
            a.Species = Input.InsertSpecies();
            a.Weight = Input.InsertWeight(a.Species);
            zoo.Add(new Animal { Species = a.Species, Weight = a.Weight });
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
                Console.WriteLine("{0}, {1} kg", a.Species, a.Weight);
            }
        }

        public void SortByName()
        {
            zoo.Sort((x, y) => x.Species.CompareTo(y.Species));
        }
    }
}
