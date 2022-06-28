using UnityEngine;

namespace Scriptable_Objects.Items.Scripts
{
    public enum ItemType
    {
        Hull,
        Shield,
        Thruster,
        Weapon,
        Upgrade,
        Default,
    }
    
    public abstract class ItemObject : ScriptableObject
    {
        public GameObject prefab;
        public ItemType type;
        
        [TextArea(15,20)] public string description;
    }
}