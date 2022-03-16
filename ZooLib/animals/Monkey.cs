using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooLib.baseClasses.animals
{
     [Serializable]
    internal class Monkey: Herbivore
    {
        public Monkey()
        {
            Species = "Monkey";
            HerbivorialFood = 5.4;
            CarnivorialFood = 0;
            Price = 15.07;
        }
}
}
