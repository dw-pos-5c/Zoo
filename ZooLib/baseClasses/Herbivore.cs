using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooLib.baseClasses
{
    [Serializable]
    internal abstract class Herbivore: Animal
    {
        public override string ToString()
        {
            return $"Herbivore '{Species}' needs {HerbivorialFood}kgs of Food per day and Costs {Price}€";
        }
    }
}
