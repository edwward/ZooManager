using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZooManager
{
    public class Animal
    {
        public int Id { get; set; }
        public string  Species { get; set; }
        public int  Weight { get; set; }
        public string Name { get; set; }

        public Animal()
        {

        }

        public Animal(int id, string species, int weight, string name)
        {
            Id = id;
            Species = species;
            Weight = weight;
            Name = name;
        }

    }
}
