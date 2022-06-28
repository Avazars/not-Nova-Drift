using System.Collections.Generic;
using Scriptable_Objects.Enemy.Scripts;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Enemy enemy;

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
