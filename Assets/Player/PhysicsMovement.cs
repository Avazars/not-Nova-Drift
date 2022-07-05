using System;
using EntityStats;
using Interfaces;
using UnityEngine;

namespace DefaultNamespace.Player
{
    public class PhysicsMovement : MonoBehaviour, IMovable
    {
        public event EventHandler<IMovable.MovementEventArgs> Moved;
        
        
        private Rigidbody2D modelRigidbody;
        [SerializeField] private GameObject rotationPoint;
        
        private IBaseEntity baseEntity;
        
        
        private MoveType rotationDirection;
        private MoveType thrustType;
        private bool rotateHeld;
        private bool thrustHeld;

        private void Start()
        {
            baseEntity = GetComponent<IBaseEntity>();
            modelRigidbody = baseEntity.GetEntityRigidBody();
        }
        
        public void SetThrusting(bool isThrusting, MoveType thrustMovement)
        {
            thrustHeld = isThrusting;
            thrustType = thrustMovement;
            Moved?.Invoke(this, new IMovable.MovementEventArgs{MoveType = thrustType});
        }

        public void SetRotating(bool isRotating, MoveType direction)
        {
            rotationDirection = direction;
            rotateHeld = isRotating;
            Moved?.Invoke(this, new IMovable.MovementEventArgs {MoveType = rotationDirection});
        }
        
        private void Thrust()
        {
            Vector2 temp = Vector2.up * baseEntity.GetStat(TypeOfStat.Acceleration);
            modelRigidbody.AddRelativeForce(temp, ForceMode2D.Impulse);
        }
        
        private void UpdateProportionalDrag()
        {
            var velocity = modelRigidbody.velocity;
            modelRigidbody.drag = (velocity.magnitude / (1.02f + (velocity.magnitude /  10)) * baseEntity.GetStat(TypeOfStat.DragScalar));
        }
        
        private void RotateRotator()
        {
            if (rotationDirection == MoveType.RotateRight)
            {
                rotationPoint.transform.Rotate(new Vector3(0,0, 1), 120 * Time.deltaTime);
            }
            else if (rotationDirection == MoveType.RotateLeft)
            {
                rotationPoint.transform.Rotate(new Vector3(0,0, -1), 120 * Time.deltaTime);
            }
           
        }
        
        private void UpdateRotation()
        {
            // put the thing that rotates here
            modelRigidbody.transform.rotation = Quaternion.Slerp(modelRigidbody.transform.rotation, rotationPoint.transform.rotation, Time.deltaTime * baseEntity.GetStat(TypeOfStat.RotationSpeed));
        }
        
        public void FixedUpdate()
        {
            if (rotateHeld){RotateRotator();}
            if (thrustHeld){Thrust();}
            UpdateProportionalDrag();
            UpdateRotation();
        }
    }
}