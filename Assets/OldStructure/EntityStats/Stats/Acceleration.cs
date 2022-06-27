using Unity.VisualScripting;

namespace Classes.EntityStats.Stats
{
    public class Acceleration : EntityStat
    {
        public Acceleration()
        {
            this.baseValue = 1.0f;
            this.Type = TypeOfStat.Acceleration;
        }
        
    }
}