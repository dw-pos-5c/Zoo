using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ZooLib.baseClasses;

public class AnimalFactory
{
    private static readonly Dictionary<string, Animal?> Animals = new();

    private static AnimalFactory? instance;

    public static AnimalFactory GetInstance()
    {
        return instance ??= new AnimalFactory();
    }

    public List<string> animalList => Animals.Keys.OrderBy(x => x).ToList();

    private AnimalFactory() { }

    static AnimalFactory() {
        Assembly.GetExecutingAssembly().GetTypes()
            .Where(x => x.BaseType != null && !x.IsAbstract && x.IsSubclassOf(typeof(Animal)))
            .ToList()
            .ForEach(x =>
            {
                var shape = Activator.CreateInstance(x) as Animal;
                Register(x.Name, shape);
            });
    }

    private static void Register(string name, Animal animal)
    {
        Animals.Add(name, animal);
    }

    public int Clones { get; set; }

    public List<Animal> Create(string name, int count)
    {
        bool exists = Animals.TryGetValue(name, out Animal? animal);
        if (!exists) throw new NotImplementedException();
        var list = new List<Animal>();
        for (var i = 0; i < count; i++)
        {
            list.Add(animal.Clone());
            Clones++;
        }
        return list;
    }

    public Animal GetInfo(string name)
    {
        bool exists = Animals.TryGetValue(name, out Animal? animal);
        if (!exists) throw new NotImplementedException();
        return animal;
    }
}

