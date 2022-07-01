using System;
using System.Collections.Generic;
using DefaultNamespace;
using Scriptable_Objects.Enemy.Scripts;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    public static event EventHandler<DamageTakenEventArgs> EnemyTakenDamage;
    public class DamageTakenEventArgs : EventArgs
    {
        public EntityType fromEntityType;
    }
    
    
    
    [SerializeField] private Enemy enemy;

    [SerializeField] private float health;
    
    
    public void TakeDamage(float damage, EntityType source)
    {
        health -= damage;
        EnemyTakenDamage?.Invoke(this,new DamageTakenEventArgs {fromEntityType = source});
    }
    
    private List<Vector2> physicsShape = new List<Vector2>();
    private SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        InitialSetSprite();
    }

    private void InitialSetSprite()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = enemy.EnemySprite;
        spriteRenderer.sprite.GetPhysicsShape(0, physicsShape);
        GetComponent<PolygonCollider2D>().SetPath(0, physicsShape);
    }
}
