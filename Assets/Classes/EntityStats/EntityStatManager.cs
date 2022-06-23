using System.Collections.Generic;
using System.Reflection;
using System;
using System.Linq;

namespace Classes.EntityStats
{
    public class EntityStatManager
    {
        // Maybe make a class that stores lists of all the things in the game so that I only have to linq and reflection
        // it once per game session.
        private readonly Dictionary<TypeOfStat, EntityStat> dictionaryOfStats = new();

        public EntityStatManager()
        {
            PopulateStatList();
        }

        private void PopulateStatList()
        {
            foreach (Type t  in FindDerivedTypes(Assembly.GetExecutingAssembly(), typeof(EntityStat)))
            {
                EntityStat instance = (EntityStat) Activator.CreateInstance(t);
                TypeOfStat bob = instance.Type;
                dictionaryOfStats.Add(instance.Type, instance);
            }
        }

        private IEnumerable<Type> FindDerivedTypes(Assembly assembly, Type baseType)
        {
            return assembly.GetTypes().Where(t => t.IsSubclassOf(baseType));
        }

        public void AddMod(StatMod mod)
        {
            if (dictionaryOfStats.ContainsKey(mod.Stat))
            {
                dictionaryOfStats[mod.Stat].AddModifier(mod);
            }
        }

        public void RemoveMods(StatMod mod)
        {
            if (dictionaryOfStats.ContainsKey(mod.Stat))
            {
                dictionaryOfStats[mod.Stat].RemoveModifier(mod);
            }
        }

        public float GetStatValue(TypeOfStat type)
        {
            if (dictionaryOfStats.ContainsKey(type))
            {
                return dictionaryOfStats[type].FinalValue;
            }

            return 0.0f;
        }
        
    }
    public enum TypeOfStat
    {
        Acceleration,
        Armor,
        DragScalar,
        EntitySize,
        FireRate,
        FiringArc,
        HullRegenRate,
        MaxHull,
        MaxShield,
        MaxVelocity,
        MultiShot,
        ProjectileLifespan,
        ProjectileSize,
        ProjectileSpeed,
        RotationSpeed,
        ShieldRechargeRate,
    }
}