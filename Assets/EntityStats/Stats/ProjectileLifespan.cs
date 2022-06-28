namespace EntityStats.Stats
{
    public class ProjectileLifespan : EntityStat
    {
        public ProjectileLifespan()
        {
            this.baseValue = 1.0f;
            this.Type = TypeOfStat.ProjectileLifespan;
        }
    }
}