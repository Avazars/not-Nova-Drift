using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Enemy/BaseEnemy")]
public class Enemy : ScriptableObject
{
    [SerializeField] private Sprite enemySprite;

    [SerializeField] private float health;


    public Sprite EnemySprite => enemySprite;

    public float Health => health;
}
