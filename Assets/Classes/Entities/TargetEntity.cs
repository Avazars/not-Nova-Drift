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
            
            statManager.MaxHull.AddModifier(new StatMod(1f,StatModType.PercentMul,0,this));
            Health = statManager.MaxHull.FinalValue;
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
