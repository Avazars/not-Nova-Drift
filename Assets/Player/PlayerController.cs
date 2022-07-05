using Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace.Player
{
    public class PlayerController : MonoBehaviour
    {
        private IMovable movementHandler;
        
        private InputActions actions;
        private InputAction thrust;
        private InputAction rotate;
        

        public void Awake()
        {
            actions = new InputActions();
        }

        public void Start()
        {
            movementHandler = GetComponent<IMovable>();
        }

        public void OnEnable()
        {
            thrust = actions.PlayerControl.Thrust;
            rotate = actions.PlayerControl.Rotate;
        
            thrust.performed += DoThrust;
            thrust.canceled += StopThrust;
        
            rotate.performed += DoRotate;
            rotate.canceled += StopRotate;
        
            thrust.Enable();
            rotate.Enable();
        }

        public void OnDisable()
        {
            thrust.Disable();
            rotate.Disable();
        }
        
        private void DoThrust(InputAction.CallbackContext obj)
        {
            movementHandler.SetThrusting(true, MoveType.ThrustStart);
        }
    
        private void StopThrust(InputAction.CallbackContext obj)
        {
            movementHandler.SetThrusting(false, MoveType.ThrustStop);
        }
    
        private void DoRotate(InputAction.CallbackContext obj)
        {
            float readValue = rotate.ReadValue<float>();
            if (readValue > 0) 
            {
                movementHandler.SetRotating(true, MoveType.RotateLeft);
            } 
            else if(readValue < 0)
            {
                movementHandler.SetRotating(true, MoveType.RotateRight);
            }
        }
    
        private void StopRotate(InputAction.CallbackContext obj)
        {
            movementHandler.SetRotating(false, MoveType.RotateNone);
        }
        
    }
}