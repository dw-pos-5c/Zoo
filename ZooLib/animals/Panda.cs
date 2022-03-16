using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooLib.baseClasses.animals
{
    [Serializable]
    internal class Panda: Herbivore
    {
        public Panda()
        {
            Species = "Bear";
            HerbivorialFood = 20;
            CarnivorialFood = 0;
            Price = 200.99;
        }
    }
}
