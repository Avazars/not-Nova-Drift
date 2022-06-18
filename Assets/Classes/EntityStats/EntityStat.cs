using System;
using System.Collections.Generic;
using System.Linq;

namespace Classes.EntityStats
{
    public abstract class EntityStat
    {
        /// <summary>
        /// this is so that I can access what stat it is from the statmanager by looping and checking its ID.
        /// </summary>
        public readonly int statID;
        
        /// <summary>
        /// the base value that will be added by the constructor.
        /// </summary>
        private readonly float baseValue;
        
        /// <summary>
        /// the final value that is calculated whenever the stat gains a modifier or a modifier is removed
        /// </summary>
        private float FinalValue { get; set; }
        
        /// <summary>
        /// the list of stat modifiers that this stat has
        /// </summary>
        private readonly List<StatMod> statMods;

        /// <summary>
        /// this is an empty constructor so that we can use linq and reflection to instantiate all the stats for an
        /// entity without providing any arguments
        /// </summary>
        protected EntityStat()
        {
        }

        /// <summary>
        /// the real constructor that I might use if I need to make a new stat for some reason.
        /// </summary>
        /// <param name="baseValue"></param>
        protected EntityStat(float baseValue)
        {
            this.baseValue = baseValue;
            FinalValue = baseValue;
            statMods = new List<StatMod>();
        }

        /// <summary>
        /// the code that adds a modifier object to this stats modifiers list
        /// the recalculates the final value.
        /// </summary>
        /// <param name="mod"></param>
        public void AddModifier(StatMod mod)
        {
            statMods.Add(mod);
            Recalculate();
        }
        
        /// <summary>
        /// the code that removes a modifier from this stats modifiers list
        /// then recalculates the final value
        /// </summary>
        /// <param name="mod"></param>
        public void RemoveModifier(StatMod mod)
        {
            statMods.Remove(mod);
            Recalculate();
        }

        /// <summary>
        /// the method that recalculates the final value based on how many modifiers are in the modifier list
        /// also takes into account what type the modifiers are so that it can do some math on them
        /// </summary>
        private void Recalculate()
        {
            float temp = baseValue;
            float sumPercentAdd = 0;
            
            var flat = from StatMod statMod in statMods where statMod.Type == StatModType.Flat select statMod ;
            var additive = from StatMod statMod in statMods where statMod.Type == StatModType.PercentAdd select statMod;
            var mult = from StatMod statMod in statMods where statMod.Type == StatModType.PercentMul select statMod;
            
            IEnumerable<StatMod> flatEnumerable = flat.ToList();
            IEnumerable<StatMod> addEnumerable = additive.ToList();
            IEnumerable<StatMod> multEnumerable = mult.ToList();
            
            if (flatEnumerable.Any())
            {
                var orderedEnumerable = flatEnumerable.OrderBy(mod => mod.Order);
                foreach (StatMod statMod in orderedEnumerable.ToList())
                {
                    temp += statMod.Value;
                }
            }

            if (addEnumerable.Any())
            {
                var orderedEnumerable = addEnumerable.OrderBy(mod => mod.Order);
                foreach (StatMod statMod in orderedEnumerable)
                {
                    sumPercentAdd += statMod.Value;
                }

                temp *= 1 + sumPercentAdd;
            }
            
            if (multEnumerable.Any())
            {
                var orderedEnumerable = multEnumerable.OrderBy(mod => mod.Order);
                foreach (StatMod statMod in orderedEnumerable)
                {
                    temp *= 1 + statMod.Value;
                }
            }

            FinalValue = (float)Math.Round(temp, 4);
        }

        /// <summary>
        /// removes All stats that originated from a specific source
        /// </summary>
        /// <param name="source"></param>
        public void removeAllStatsFromSource(object source)
        {
            foreach (StatMod statMod in statMods)
            {
                if (statMod.Source == source)
                {
                    statMods.Remove(statMod);
                }
            }
            Recalculate();
        }
    }
}