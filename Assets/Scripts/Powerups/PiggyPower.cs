using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggyPower : MonoBehaviour
{
    private Player player;
    public PiggyAIController piggy;
    public Vector3 rotationSpeed = Vector3.zero;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public virtual void activate() { }

    protected void EnablePlayerHighJump()
    {
        player.AcquireHighJumpAbility();
    }

    protected void EnablePlayerFire()
    {
        player.AcquireFireAbility();
    }

    protected void EnablePlayerGlide()
    {
        player.AcquireGlideAbility();
    }

    private void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
