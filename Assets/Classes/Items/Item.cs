using System.Collections.Generic;
using Classes.EntityStats;
using Classes.Interfaces;

namespace Classes.Items
{
    public class Item : IEquippable
    {
        public List<StatMod> ModList { get; } = new List<StatMod>();
        
        protected Item()
        {
        }

        
        public virtual void EquipItem()
        {
            
        }

        public virtual void UnEquipItem()
        {
            
        }
    }
}