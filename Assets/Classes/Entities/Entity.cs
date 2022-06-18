using System;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Entity : MonoBehaviour, IDamageable, IMovable
    {
        private Rigidbody2D entityRigidbody;
        public float Health { get; set; }
        
        
        public virtual void Start()
        {
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
            entityRigidbody.drag = velocity.magnitude / (1.01f + (velocity.magnitude /  10) * 0.9f);
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