using EntityStats;
using UnityEngine;

namespace Interfaces
{
    public interface IBaseEntity
    {
        public float GetStat(TypeOfStat typeOfStat);
        public void AddStatModifier();
        public void RemoveStatModifier();

        public Rigidbody2D GetEntityRigidBody();
    }
}