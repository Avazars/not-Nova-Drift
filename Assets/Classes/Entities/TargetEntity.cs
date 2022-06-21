using Classes.EntityStats;
using DefaultNamespace;

    public class TargetEntity : ShipEntity
    {
        public override void Start()
        {
            base.Start();
            statManager.MaxHull.AddModifier(new StatMod(1f,StatModType.PercentMul,0,this));
            Health = statManager.MaxHull.FinalValue;
        }

        public override void Update()
        {
            base.Update();
        }
    }
