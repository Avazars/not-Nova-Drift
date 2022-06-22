using Classes.EntityStats.Stats;

namespace Classes.EntityStats
{
    public class EntityStatManager
    {
        public Acceleration Acceleration = new Acceleration();
        public Armor Armor = new Armor();
        public DragScalar DragScalar = new DragScalar();
        public EntitySize EntitySize = new EntitySize();
        public FireRate FireRate = new FireRate();
        public FiringArc FiringArc = new FiringArc();
        public HullRegenRate HullRegenRate = new HullRegenRate();
        public MaxHull MaxHull = new MaxHull(5.0f);
        public MaxShield MaxShield = new MaxShield();
        public MaxVelocity MaxVelocity = new MaxVelocity();
        public MultiShot MultiShot = new MultiShot();
        public ProjectileLifespan ProjectileLifespan = new ProjectileLifespan();
        public ProjectileSize ProjectileSize = new ProjectileSize();
        public ProjectileSpeed ProjectileSpeed = new ProjectileSpeed();
        public RotationSpeed RotationSpeed = new RotationSpeed();
        public ShieldRechargeRate ShieldRechargeRate = new ShieldRechargeRate();
    
    
    
    }
}