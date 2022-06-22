using Classes.EntityStats;
using Classes.Interfaces;
using UnityEngine;

namespace Classes.Entities
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Entity : MonoBehaviour, IDamageable, IMovable
    {
        private Rigidbody2D entityRigidbody;
        protected EntityStatManager statManager;
        
        
        public float Health { get; set; }
        public float Shield { get; set; }
        
        public virtual void Start()
        {
            statManager = new EntityStatManager();
            entityRigidbody = gameObject.GetComponent<Rigidbody2D>();
        }

        public virtual void Update()
        {
            if (Health <= 0)
                Destroy(gameObject);
            
            UpdateProportionalDrag();
        }
        
        
        
        private void UpdateProportionalDrag()
        {
            var velocity = entityRigidbody.velocity;
            entityRigidbody.drag = (velocity.magnitude / (1.02f + (velocity.magnitude /  10)) * 1.1f);
        }
        
        public virtual void Damage(float amount)
        {
            Health -= amount;
        }
        
        public virtual void Rotate(float impulse)
        {
            entityRigidbody.AddTorque(impulse, ForceMode2D.Impulse);
        }

        public virtual void Thrust(float force)
        {
            Vector2 temp = Vector2.up*force; 
            entityRigidbody.AddRelativeForce(temp, ForceMode2D.Impulse);
        }
        
    }
}