using Classes.EntityStats;
using Classes.Interfaces;
using Classes.Items;

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
            throw new System.NotImplementedException();
        }

        public virtual void Update()
        {
            if (Health <= 0)
                Destroy(gameObject);
        }
    }
}