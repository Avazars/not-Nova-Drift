using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class AsteroidEntity : EnvironmentEntity
    {
        public float asteroidHealth;

        public override void Start()
        {
            base.Start();
            Health = asteroidHealth;
        }

        public override void Update()
        {
            base.Update();
            
            //Replace with a function called movement
            //Vector2 vec = Vector2.up * 0.5f;
            //Thrust(vec);
            //Rotate(0.5f * Mathf.Deg2Rad);
        }
    }
}