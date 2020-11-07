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
        public string  Species { get; set; }
        public int  Weight { get; set; }

        public Animal()
        {

        }

        public Animal(string species, int weight)
        {
            Species = species;
            Weight = weight;
        }

    }
}
