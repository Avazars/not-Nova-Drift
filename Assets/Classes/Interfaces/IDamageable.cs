namespace DefaultNamespace
{
    public interface IDamageable
    {
        public float Health { get; set; }
        public float Shield { get; set; }
        void Damage(float amount);
    }
}