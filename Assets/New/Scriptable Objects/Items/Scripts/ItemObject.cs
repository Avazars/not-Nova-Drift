using UnityEngine;

namespace New.Scriptable_Objects.Items.Scripts
{
    public enum ItemType
    {
        Hull,
        Shield,
        Thruster,
        Weapon,
        Upgrade,
    }
    
    public abstract class ItemObject : ScriptableObject
    {
    }
}