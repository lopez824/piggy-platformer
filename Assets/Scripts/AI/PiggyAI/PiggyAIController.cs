using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggyAIController : MonoBehaviour
{
    private PiggyState currentState;
    [HideInInspector]
    public Rigidbody rb;
    [HideInInspector]
    public GameObject player;

    public Animator anim;
    public AudioSource sound;
    public string oinkName;
    public float movementSpeed = 3f;
    public float turnSpeed = 20f;
    public bool isGrounded = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentState = new PiggyIdle(this);
        currentState.enter();
    }

    public void ChangeState(string eventName)
    {
        PiggyState newState = currentState.handleEvent(eventName);

        if (newState != null)
        {
            currentState.exit();
            currentState = newState;
            currentState.enter();
        }
    }

    public void ChangeGroundState()
    {
        PiggyState newState;
        if (rb.velocity.x < 1 && rb.velocity.z < 1)
            newState = new PiggyIdle(this);
        else
            newState = new PiggyFollow(this);

        if (newState != null)
        {
            currentState.exit();
            currentState = newState;
            currentState.enter();
        }
    }

    public void MoveTo(Vector3 location)
    {
        RotateTo(location);
        transform.Translate(0, 0, movementSpeed * Time.deltaTime);
    }

    public void RotateTo(Vector3 location)
    {
        Vector3 targetDirection = location - transform.position;
        Vector3 currentDirection = transform.forward;        // we want to use our forward direction

        Debug.DrawRay(transform.position, currentDirection, Color.red, 2f);     // useful for visualizing vectors
        Debug.DrawRay(transform.position, targetDirection, Color.blue, 2f);

        Quaternion lookAtPoint = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookAtPoint, Time.deltaTime * turnSpeed);
    }

    public float GetDistanceTo(Vector3 location)
    {
        float distance = Vector3.Distance(location, transform.position);
        return distance;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isGrounded == false)
        {
            isGrounded = true;
            ChangeGroundState();
        }
    }

    private void FixedUpdate()
    {
        currentState.update();
    }
}
