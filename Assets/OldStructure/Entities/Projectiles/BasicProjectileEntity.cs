namespace Classes.Entities.Projectiles
{
    public class BasicProjectileEntity : ProjectileEntity
    {

        public float projectileLifetime;
        public float projectileDamage;
        public float initialVelocity;

        public override void Start()
        {
            Lifetime = projectileLifetime;
            ProjectileDamage = projectileDamage;
            InitialVelocity = initialVelocity;
            base.Start();
        }
    }
}
