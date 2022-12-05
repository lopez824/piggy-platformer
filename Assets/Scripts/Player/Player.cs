using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.InputSystem.Utilities;

public class Player : MonoBehaviour
{
    private PlayerState currentState;
    private PlayerInputActions playerActions;
    private Rigidbody rb;
    private GameObject[] piggyList;
    private List<PiggyAIController> piggies;
    private ParticleSystem flameBreath;
    [SerializeField]
    private BoxCollider breathHitbox;
    private Vector2 playerInput = Vector2.zero;
    private Vector3 velocity = Vector3.zero;
    private Vector3 desiredVelocity = Vector3.zero;
    private bool acquiredHighJump = false;
    private bool acquiredFire = false;
    private bool acquiredGlide = false;

    public Animator anim;
    public Player player;
    public Rigidbody rigidBody;
    public AudioSource sound;
    public float jumpForce = 250f;
    public float flyForce = 3f;
    public float movementSpeed = 5f;
    public float movementAccel = 10f;
    public float rotationSpeed = 720f;
    public bool isGrounded = true;
    public bool isGliding = false;

    private void Awake()
    {
        playerActions = new PlayerInputActions();
        piggies = new List<PiggyAIController>();
        rb = GetComponent<Rigidbody>();
        flameBreath = GetComponentInChildren<ParticleSystem>();
    }

    private void OnEnable()
    {
        playerActions.Player.Enable();
    }

    private void Start()
    {
        piggyList = GameObject.FindGameObjectsWithTag("Piggy");
        foreach (GameObject piggy in piggyList)
        {
            piggies.Add(piggy.GetComponent<PiggyAIController>());
        }

        //Debug.Log(piggies.Count);
        currentState = new IdleState(player);
        currentState.enter();
    }

    public void AcquireHighJumpAbility()
    {
        acquiredHighJump = true;
    }

    public void AcquireFireAbility()
    {
        acquiredFire = true;
    }

    public void AcquireGlideAbility()
    {
        acquiredGlide = true;
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (context.interaction is HoldInteraction && acquiredFire == true)
            {
                breathHitbox.enabled = true;
                flameBreath.Play();
                ChangeState(context);
            }
            else if (context.interaction is TapInteraction)
            {
                ChangeState(context);
            }
        }

        if (context.canceled && acquiredFire == true)
        {
            breathHitbox.enabled = false;
            flameBreath.Stop();
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ChangeState(context);
            foreach(PiggyAIController piggy in piggies)
            {
                piggy.ChangeState(context.action.name);
            }
        }
            
        if (context.canceled)
        {
            ChangeState(context);
            foreach (PiggyAIController piggy in piggies)
            {
                piggy.ChangeState("MoveCancel");
            }
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded == true)
        {
            //Debug.Log("Jump Performed");
            //Debug.Log(context.interaction);
            isGrounded = false;
            ChangeState(context);
            
            if (context.interaction is TapInteraction || acquiredHighJump == false)
                rb.AddForce(Vector2.up * jumpForce);
            else if (context.interaction is HoldInteraction && acquiredHighJump == true)
            {
                rb.AddForce(Vector2.up * jumpForce * 1.5f);
                
                if (acquiredGlide == true)
                    isGliding = true;
            }
                

            foreach (PiggyAIController piggy in piggies)
            {
                piggy.isGrounded = false;
                piggy.ChangeState(context.action.name);
                piggy.rb.AddForce(Vector2.up * jumpForce * 0.8f);
            }
        }   
        else if (context.canceled)
        {
            //Debug.Log("Jump Canceled");
            isGliding = false;
            ChangeState(context);
        }
    }

    private void ChangeState(InputAction.CallbackContext context)
    {
        PlayerState newState = currentState.handleInput(context);

        if (newState != null)
        {
            currentState.exit();
            currentState = newState;
            currentState.enter();
        }
    }

    private void ChangeGroundState()
    {
        PlayerState newState;
        if (rb.velocity.x < 1 && rb.velocity.z < 1)
            newState = new IdleState(player);
        else
            newState = new WalkingState(player);

        if (newState != null)
        {
            currentState.exit();
            currentState = newState;
            currentState.enter();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isGrounded == false)
        {
            isGrounded = true;
            ChangeGroundState();
        }
    }

    private void OnDisable()
    {
        playerActions.Player.Disable();
    }

    private void Update()
    {
        playerInput.x = playerActions.Player.Move.ReadValue<Vector2>().x;
        playerInput.y = playerActions.Player.Move.ReadValue<Vector2>().y;
        playerInput = Vector2.ClampMagnitude(playerInput, 1f);

        desiredVelocity = new Vector3(playerInput.x, 0f, playerInput.y) * movementSpeed;
    }

    private void FixedUpdate()
    {
        velocity = rb.velocity;
        float speedDelta = movementAccel * Time.deltaTime;
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, speedDelta);
        velocity.z = Mathf.MoveTowards(velocity.z, desiredVelocity.z, speedDelta);

        rb.velocity = velocity;

        if (desiredVelocity == Vector3.zero)
            return;
        Quaternion targetRotation = Quaternion.LookRotation(desiredVelocity);
        targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(targetRotation);

        if (isGliding == true)
            rb.AddForce(Vector2.up * flyForce);
    }
}
