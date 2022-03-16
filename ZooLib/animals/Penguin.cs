using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooLib.baseClasses.animals
{
    [Serializable]
    internal class Penguin: Carnivore

    {
    public Penguin()
    {
        Species = "Penguin";
        HerbivorialFood = 0;
        CarnivorialFood = 12.0;
        Price = 109.99;
    }
    }
}
