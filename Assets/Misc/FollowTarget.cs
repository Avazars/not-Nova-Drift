using UnityEngine;

namespace Misc
{
    public class FollowTarget : MonoBehaviour
    {

        public Transform myTarget;
        
        // Update is called once per frame
        void Update()
        {
            Vector3 targPos = myTarget.position;
            
            var thisTransform = transform;
            var position = thisTransform.position;
            
            targPos.z = position.z;
            position = new Vector3(targPos.x, targPos.y, targPos.z);
            thisTransform.position = position;
        }
    }
}