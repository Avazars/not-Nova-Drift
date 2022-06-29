using System;
using UnityEngine;

public class PlayerEventHandler : MonoBehaviour
{
        public event EventHandler<GameObject> EnemyDestroyed;
        
        protected virtual void OnEnemyDestroyed(GameObject destroyedEnemy)
        {
                EnemyDestroyed?.Invoke(this, destroyedEnemy);
        }
}