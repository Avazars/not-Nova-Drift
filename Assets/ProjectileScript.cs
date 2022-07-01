using System;
using DefaultNamespace;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    // projectile scriptable object

    [SerializeField] private float damage;
    
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<EnemyBehaviour>().TakeDamage(damage, EntityType.Player);
            Destroy(gameObject);
        }
    }
}