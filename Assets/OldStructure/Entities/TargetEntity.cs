using Classes.EntityStats;
using UnityEngine;
using UnityEngine.UI;

namespace Classes.Entities
{
    public class TargetEntity : EnemyEntity
    {
        private Slider healthSlider;
        public GameObject healthBar;
        public override void Start()
        {
            base.Start();

            healthSlider = healthBar.GetComponent<Slider>();
            
            statManager.AddMod(new StatMod(1f,StatModType.PercentMul, TypeOfStat.MaxHull,0,this));
            Health = statManager.GetStatValue(TypeOfStat.MaxHull);
            healthSlider.maxValue = Health;
            
            healthSlider.minValue = 0;
        }

        public override void Update()
        {
            base.Update();
            healthSlider.value = Health;
        }
    }
}
