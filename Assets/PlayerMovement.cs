using DefaultNamespace;
using UnityEngine;
using UnityEngine.InputSystem;



[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : ShipEntity
{
    private InputActions actions;
    private InputAction thrust;
    private InputAction rotate;
    private InputAction fire;

    public float health;
    public float speed;
    public float rotationSpeed;
    public float weaponCooldownInSeconds;
    float impulse;

    private float timeStamp;
    private bool rotateHeld;
    private bool thrustHeld;
    private bool fireHeld;
    
    public GameObject projectile;
    public GameObject shootSpot;

    private CoolDownTimer coolDownTimer;
    
    private void Awake()
    {
        actions = new InputActions();
    }

    public override void Start()
    {
        coolDownTimer = new CoolDownTimer(weaponCooldownInSeconds);
        Health = health;
        base.Start();
    }

    private void OnEnable()
    {
        
        thrust = actions.PlayerControl.Thrust;
        rotate = actions.PlayerControl.Rotate;
        fire = actions.PlayerControl.Fire;
        
        thrust.performed += DoThrust;
        thrust.canceled += StopThrust;
        
        rotate.performed += DoRotate;
        rotate.canceled += StopRotate;
        
        fire.performed += DoFire;
        fire.canceled += StopFire;
        
        thrust.Enable();
        rotate.Enable();
        fire.Enable();
    }
    
    private void OnDisable()
    {
        thrust.Disable();
        actions.PlayerControl.Thrust.Disable();
        actions.PlayerControl.Fire.Disable();
        actions.PlayerControl.Rotate.Disable();
    }
    
    private void DoThrust(InputAction.CallbackContext obj)
    {
        thrustHeld = true;
    }
    private void StopThrust(InputAction.CallbackContext obj)
    {
        thrustHeld = false;
    }
    private void DoRotate(InputAction.CallbackContext obj)
    {
        rotateHeld = true;
        float readValue = rotate.ReadValue<float>();
        if (readValue > 0) 
        {
            impulse = (-rotationSpeed * Mathf.Deg2Rad);
        } 
        else if(readValue < 0)
        {
            impulse = (rotationSpeed * Mathf.Deg2Rad);
        }
    }
    private void StopRotate(InputAction.CallbackContext obj)
    {
        rotateHeld = false;
    }
    private void DoFire(InputAction.CallbackContext obj)
    {
        fireHeld = true;
    }
    private void StopFire(InputAction.CallbackContext obj)
    {
        fireHeld = false;
    }

    private void shoot()
    {
        if (coolDownTimer.CoolDownComplete)
        {
            Instantiate(projectile, shootSpot.transform.position, shootSpot.transform.rotation);
            coolDownTimer.StartCoolDownTimer();
        }
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (rotateHeld)
        {
            Rotate(impulse);
        }

        if (fireHeld)
        {
            shoot();
        }
        
        if (thrustHeld)
        {
            Thrust(speed);
        }
    }
}
