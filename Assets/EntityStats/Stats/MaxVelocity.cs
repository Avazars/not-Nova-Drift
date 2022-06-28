namespace EntityStats.Stats
{
    public class MaxVelocity : EntityStat
    {
        public MaxVelocity()
        {
            this.baseValue = 1.0f;
            this.Type = TypeOfStat.MaxVelocity;
        }
    }
}