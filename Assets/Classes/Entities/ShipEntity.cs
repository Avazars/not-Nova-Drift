using UnityEngine;

namespace DefaultNamespace
{
    public class ShipEntity : Entity
    {
        private ShipItemManager itemManager;
        
        public override void Start()
        {
            base.Start();
            itemManager = new ShipItemManager();
            foreach (var thing in itemManager.allHulls)
            {
                Debug.Log(thing);
            }
        }
    }
}