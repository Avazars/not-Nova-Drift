using UnityEngine;

namespace Scriptable_Objects.Items.Scripts
{
    [CreateAssetMenu (fileName = "New Weapon Object", menuName = "Inventory System/Items/ShipPart/Weapon")]
    public class WeaponObject : ShipPart
    {
        public void Awake()
        {
            type = ItemType.Weapon;
        }
    }
}