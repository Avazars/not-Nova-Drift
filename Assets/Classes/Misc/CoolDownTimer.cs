using UnityEngine;

namespace DefaultNamespace
{
    public class CoolDownTimer
    {
        private float coolDownCompletedTime;
        private float CoolDownTime { get; set; }
        
        public bool CoolDownComplete => Time.time > coolDownCompletedTime;
        
        public CoolDownTimer(float coolDownTime)
        {
            CoolDownTime = coolDownTime;
        }

        public void StartCoolDownTimer()
        {
            coolDownCompletedTime = Time.time + CoolDownTime;
        }
        
        public void UpdateCoolDownTime(float timeChange)
        {
            CoolDownTime += timeChange;
        }
    }
}