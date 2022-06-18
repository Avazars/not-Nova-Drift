namespace DefaultNamespace
{
    public interface IDamageable
    {
        public float Health { get; set; }
        void Damage(float amount);
    }
}