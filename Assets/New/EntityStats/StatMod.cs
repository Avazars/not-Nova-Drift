namespace Classes.EntityStats
{
    public class StatMod
    {
        public readonly float Value;
        public readonly StatModType Type;
        public readonly TypeOfStat Stat;
        public readonly int Order;
        public readonly object Source;
        
        public StatMod(float value, StatModType type, TypeOfStat stat, int order, object source)
        {
            Value = value;
            Type = type;
            Stat = stat;
            Order = order;
            Source = source;
        }
        
    }

    public enum StatModType
    {
        Flat,
        PercentMul,
        PercentAdd,
    }
    
}