using DefaultNamespace;
using UnityEngine;


public class EnemyBehavior : MonoBehaviour
{
    public float health = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("PlayerProjectile") )
        {
            
        }
    }
}
