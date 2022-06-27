using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    
    private Rigidbody2D modelRigidbody;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject rotationPoint;
    
    private InputActions actions;
    private InputAction thrust;
    private InputAction rotate;
    
    private bool rotateHeld = false;
    private bool thrustHeld = false;

    private float impulse;
    
    [SerializeField] private float rotationSpeed;

    private void Start()
    {
        modelRigidbody = target.GetComponent<Rigidbody2D>();
    }
    private void Awake()
    {
        actions = new InputActions();
    }
    private void OnEnable()
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
    private void OnDisable()
    {
        actions.PlayerControl.Thrust.Disable();
        actions.PlayerControl.Rotate.Disable();
    }
    private void DoThrust(InputAction.CallbackContext obj)
    {
        thrustHeld = true;
        Debug.Log("on");
    }
    private void StopThrust(InputAction.CallbackContext obj)
    {
        thrustHeld = false;
        Debug.Log("off");
    }
    private void DoRotate(InputAction.CallbackContext obj)
    {
        rotateHeld = true;
        float readValue = rotate.ReadValue<float>();
        if (readValue > 0) 
        {
            impulse = -1;
        } 
        else if(readValue < 0)
        {
            impulse = 1;
        }
    }
    private void StopRotate(InputAction.CallbackContext obj)
    {
        rotateHeld = false;
    }
    private void UpdateProportionalDrag()
    {
        var velocity = modelRigidbody.velocity;
        modelRigidbody.drag = (velocity.magnitude / (1.02f + (velocity.magnitude /  10)) * 1.1f);
    }

    private void Rotate(float rotation)
    {
        modelRigidbody.AddTorque(rotation, ForceMode2D.Impulse);
    }

    private void Thrust(float force)
    {
        Vector2 temp = Vector2.up*force; 
        modelRigidbody.AddRelativeForce(temp, ForceMode2D.Impulse);
    }

    private void RotateRotator()
    {
        rotationPoint.transform.RotateAround(target.transform.position, new Vector3(0,0,impulse), 60 * Time.deltaTime);
    }

    private void UpdateRotation()
    {
        modelRigidbody.transform.rotation = Quaternion.Slerp(modelRigidbody.transform.rotation, rotationPoint.transform.rotation, Time.deltaTime * rotationSpeed);
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (thrustHeld) Thrust(0.1f);

        UpdateProportionalDrag();
        UpdateRotation();
         
        if (rotateHeld) RotateRotator();
    }


}
