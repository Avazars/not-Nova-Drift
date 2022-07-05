using EntityStats;
using Interfaces;
using UnityEngine;

public class PlayerBase : MonoBehaviour, IBaseEntity
{
    [SerializeField] private Rigidbody2D baseRigidbody2D;
    private EntityStatManager statManager;

    private void Awake()
    {
        statManager = new EntityStatManager();
    }

    private void Start()
    {
        statManager.AddMod(new StatMod(1, StatModType.Flat, TypeOfStat.DragScalar, 0, this));
        statManager.AddMod(new StatMod(1, StatModType.Flat, TypeOfStat.Acceleration, 0, this));
        statManager.AddMod(new StatMod(1, StatModType.Flat, TypeOfStat.RotationSpeed, 0, this));
    }

    public float GetStat(TypeOfStat typeOfStat)
    {
       return statManager.GetStatValue(typeOfStat);
    }

    public void AddStatModifier()
    {
        throw new System.NotImplementedException();
    }

    public void RemoveStatModifier()
    {
        throw new System.NotImplementedException();
    }

    public Rigidbody2D GetEntityRigidBody()
    {
        return baseRigidbody2D;
    }

}




