using UnityEngine;

namespace New.Scriptable_Objects.Items.Scripts
{
    [CreateAssetMenu (fileName = "New Weapon Object", menuName = "Inventory System/Items/Weapon")]
    public class WeaponObject : ItemObject
    {
        public void Awake()
        {
            type = ItemType.Weapon;
        }
    }
}