using Classes.Interfaces;
using UnityEngine;

namespace Classes.Entities
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Entity : MonoBehaviour, IMovable
    {
        private Rigidbody2D entityRigidbody;
        
        
        public virtual void Start()
        {
            entityRigidbody = gameObject.GetComponent<Rigidbody2D>();
        }
        
        protected void UpdateProportionalDrag()
        {
            var velocity = entityRigidbody.velocity;
            entityRigidbody.drag = (velocity.magnitude / (1.02f + (velocity.magnitude /  10)) * 1.1f);
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