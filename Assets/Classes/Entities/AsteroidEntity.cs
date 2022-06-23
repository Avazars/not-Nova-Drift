namespace Classes.Entities
{
    public class AsteroidEntity : DamageableEntity
    {
        public float asteroidHealth;

        public override void Start()
        {
            base.Start();
            Health = asteroidHealth;
        }
        
    }
}