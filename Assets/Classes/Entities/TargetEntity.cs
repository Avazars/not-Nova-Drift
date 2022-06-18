using DefaultNamespace;

    public class TargetEntity : ShipEntity
    {
        public float targetHealth;

        public override void Start()
        {
            base.Start();
            Health = targetHealth;
        }
    }
