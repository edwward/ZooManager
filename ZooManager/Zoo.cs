using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManager
{
    class Zoo
    {
        private Animal a = new Animal();
        public List<Animal> zoo { get; set; }

        public Zoo()
        {
            zoo = new List<Animal>();
        }

        private Animal FindAnimalObject(string animal, List<Animal> list)
        {
            foreach (Animal item in list)
            {
                if (item.Species.Contains(animal))
                    return item;
            }
            return null;
        }

        public void RemoveAnimalObject(string animalToDelete, List<Animal> list)
        {
            if (FindAnimalObject(animalToDelete, list) != null)
            {
                list.RemoveAll(a => a.Species == animalToDelete);
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

        public void AddAnimalObject(List<Animal> list)
        {
            a.Species = Input.InsertSpecies();
            a.Weight = Input.InsertWeight(a.Species);
            list.Add(new Animal { Species = a.Species, Weight = a.Weight });
        }

        public bool IsListEmpty(List<Animal> list)
        {
            if (list.Count == 0)
            {
                return false;
            }
            return true;
        }

        public void SortByName(List<Animal> list)
        {
            list.Sort((x, y) => x.Species.CompareTo(y.Species));
        }
    }
}
