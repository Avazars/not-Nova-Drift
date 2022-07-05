using Interfaces;
using UnityEngine;

public class PlayerEventTestingScript : MonoBehaviour
{

    private IMovable MovementTester;
    
    private void Start()
    {
        MovementTester = GetComponent<IMovable>();
        EnemyBehaviour.EnemyTakenDamage += IHitTarget;
        MovementTester.Moved += testMovement;
    }

    private void testMovement(object sender, IMovable.MovementEventArgs e)
    {
        Debug.Log(e.MoveType);
    }
    
    private void IHitTarget(object sender, EnemyBehaviour.DamageTakenEventArgs e)
    {
        if (e.fromEntityType == EntityType.Player)
        {
            Debug.Log("yay!");
        }
    }
    
    

}
