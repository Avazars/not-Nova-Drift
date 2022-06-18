using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using System.Reflection;

public class ShipItemManager 
{
    
    public List<Hull> allHulls;
    public List<Shield> allShields;
    public List<Thruster> allThrusters;
    public List<Weapon> allWeapons;

    public ShipItemManager()
    {
        getHulls();
    }

    private void getHulls()
    {
        var tempList = new List<Hull>();
        foreach (Type t in FindDerivedTypes(Assembly.GetExecutingAssembly(),typeof(Hull))) 
        {
            var instance = (Hull) Activator.CreateInstance(t);
            tempList.Add(instance);
        }

        allHulls = tempList;
    }


    private IEnumerable<Type> FindDerivedTypes(Assembly assembly, Type baseType) 
    {
        return assembly.GetTypes().Where(t => t != baseType && baseType.IsAssignableFrom(t));
    }
        
}
