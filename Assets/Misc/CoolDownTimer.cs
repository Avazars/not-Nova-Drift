using UnityEngine;

namespace Misc
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
        
        public void IncreaseCoolDownTime(float timeChange)
        {
            CoolDownTime += timeChange;
        }

        public void RestartCoolDownTimer()
        {
            coolDownCompletedTime = Time.time + CoolDownTime;
        }
    }
}