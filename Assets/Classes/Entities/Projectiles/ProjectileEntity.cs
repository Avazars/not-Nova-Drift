using UnityEngine;

namespace Classes.Entities.Projectiles
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class ProjectileEntity : Entity
    {
        protected float Lifetime { get; set; }
        protected float ProjectileDamage { get; set; }
        protected float InitialVelocity { get; set; }
    
        private float unloadTimeStamp;

        public override void Start()
        {
            base.Start();
            unloadTimeStamp = Time.time + Lifetime;
            Thrust(InitialVelocity);
        }
        
        public void Update()
        {
            TimedDeath();
        }
    
        private void TimedDeath()
        {
            if (unloadTimeStamp < Time.time)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
        
            if (col.gameObject.TryGetComponent(out DamageableEntity hitEntity))
            {
                Destroy(gameObject);
                hitEntity.Damage(ProjectileDamage);
            }

            Debug.Log("Bullet hit: " + col.name);
        }
    
    }
}