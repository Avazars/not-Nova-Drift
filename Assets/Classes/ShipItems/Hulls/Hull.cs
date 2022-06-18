using System;

namespace DefaultNamespace
{
    /// <summary>
    /// Abstract hull class that will be inherited by all the hulls in the game.
    /// 
    /// </summary>
    public abstract class Hull 
    {
        protected Hull()
        {
        }

        public static string hullName;
        private int hullValue;
        private int flatDamageReduction;
        
        // inventory type indicator... maybe a number... just so that the player object can load it in properly and
        // change it when you switch hulls
        //Todo inventory indicator

        /// <summary>
        /// amount of damage that the hull can take before the entity dies.
        /// used to calculate the amount of health an entity has.
        /// </summary>
        protected int HullValue
        {
            set => hullValue = value;
        }

        /// <summary>
        /// the amount of damage that the hull subtracts from the damage dealt.
        /// </summary>
        protected int FlatDamageReduction
        { 
            set => flatDamageReduction = value;
        }
        
        public int GetHull()
        {
            return this.hullValue;
        }

        public int GetHullDamageReduction()
        {
            return this.flatDamageReduction;
        }

        public void EquipItem()
        {
            throw new NotImplementedException();
        }

        public void UnEquipItem()
        {
            throw new NotImplementedException();
        }
    }
    
}