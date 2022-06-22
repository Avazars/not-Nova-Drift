namespace Classes.Entities
{
    public class AsteroidEntity : EnvironmentEntity
    {
        public float asteroidHealth;

        public override void Start()
        {
            base.Start();
            Health = asteroidHealth;
        }
        
    }
}