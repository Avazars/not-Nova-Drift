using System;
using System.Collections.Generic;
using New.Scriptable_Objects.Items.Scripts;
using UnityEngine;

namespace New.Scriptable_Objects.Inventory.Scripts
{
    
    [CreateAssetMenu(fileName = "New Inventory",  menuName = "Inventory System/Inventory")]
    public class InventoryObject : ScriptableObject
    {
        public List<InventorySlot> Container = new List<InventorySlot>();

        public void AddItemToInventory(ItemObject itemToAdd, int amountToAdd)
        {
            bool hasItem = false;
            foreach (var slot in Container)
            {
                if (slot.item == itemToAdd)
                {
                    slot.AddAmount(amountToAdd);
                    hasItem = true; 
                    break;
                }
            }

            if (!hasItem)
            {
                Container.Add(new InventorySlot(itemToAdd, amountToAdd));
            }
            
        }
    }

    [Serializable]
    public class InventorySlot
    {
        public ItemObject item;
        public int amount;

        public InventorySlot(ItemObject initItem, int initAmount)
        {
            item = initItem;
            amount = initAmount;
        }

        public void AddAmount(int amountToAdd)
        {
            amount += amountToAdd;
        }
    }
    
}