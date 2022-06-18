using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace DefaultNamespace
{
    public interface IMovable
    {
        public void Rotate(float impulse);
        public void Thrust(float force);

        private void UpdateProportionalDrag(){}
    }
}