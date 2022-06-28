using System;
using UnityEngine;

namespace New.Scriptable_Objects.Items.Scripts
{
    [CreateAssetMenu (fileName = "New Default Object", menuName = "Inventory System/Items/Default")]
    public class DefaultObject : ItemObject
    {
        public void Awake()
        {
            type = ItemType.Default;
        }
    }
}