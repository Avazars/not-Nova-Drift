using UnityEngine;

namespace Misc
{
    [RequireComponent(typeof(Collider2D))]
    public class PlayerDetector : MonoBehaviour
    {
        private bool InRange { get; set; }
        private GameObject target;
        private Vector3 targetLocation;

        public Vector3 TargetLocation => targetLocation;
        
        public void Update()
        {
            if (InRange)
            {
                targetLocation = target.transform.position;
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject == target)
                InRange = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            InRange = false;
        }
        
        
    }
}