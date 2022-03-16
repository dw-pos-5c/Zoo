using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ZooLib.baseClasses;

[Serializable]
public abstract class Animal
{
    public string Species { get; set; }
    public double HerbivorialFood { get; set; }
    public double CarnivorialFood { get; set; }
    public double Price { get; set; }

    public Animal Clone()
    {
        var stream = new MemoryStream();
        var formatter = new BinaryFormatter();
        formatter.Serialize(stream, this);
        stream.Seek(0, SeekOrigin.Begin);
        var copy = (Animal)formatter.Deserialize(stream);
        stream.Close();
        return copy;
    }
}
