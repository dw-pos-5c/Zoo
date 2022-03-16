﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooLib.baseClasses
{
    [Serializable]
    internal abstract class Carnivore: Animal
    {
        public override string ToString()
        {
            return $"Carnivore '{Species}' needs {CarnivorialFood}kgs of Food per day and Costs {Price}€";
        }
    }
}
