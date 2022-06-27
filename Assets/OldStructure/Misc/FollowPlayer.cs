using UnityEngine;

namespace Classes.Misc
{
    public class FollowPlayer : MonoBehaviour
    {

        public Transform myTarget;
        
        // Update is called once per frame
        void Update()
        {
            Vector3 targPos = myTarget.position;
            var transform1 = transform;
            targPos.z = transform1.position.z;
            transform1.position = targPos;
        }
    }
}
