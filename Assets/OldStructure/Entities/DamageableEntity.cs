using Classes.EntityStats;
using Classes.Interfaces;
using Classes.Items;
using UnityEngine.UIElements;

namespace Classes.Entities
{
    public class DamageableEntity : Entity, IDamageable
    {
        public float Health { get; set; }
        public float Shield { get; set; }
        
        protected EntityStatManager statManager;
        protected ItemHandler itemHandler;

        public DamageableEntity()
        {
            statManager = new EntityStatManager();
            itemHandler = new ItemHandler(ref statManager);
        }

        public void Damage(float amount)
        {
            Health -= amount;
        }

        public virtual void Update()
        {
            UpdateProportionalDrag();
            if (Health <= 0)
                Destroy(gameObject);
        }
    }
}