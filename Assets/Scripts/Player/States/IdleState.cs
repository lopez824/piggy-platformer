using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IdleState : PlayerState
{
    public IdleState(Player _player) : base(_player)
    {
        player = _player;
    }

    public override void enter()
    {
        //Debug.Log("Enter Idle");
        player.anim.SetTrigger("isIdle");
    }

    public override PlayerState handleInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            switch (context.action.name)
            {
                case "Attack":
                    return new AttackState(player);
                case "Move":
                    return new WalkingState(player);
                case "Jump":
                    return new JumpState(player);
            }
        }

        return null;
    }

    public override void update()
    {
        base.update();
    }

    public override void exit()
    {
        //Debug.Log("Exit Idle");
        player.anim.ResetTrigger("isIdle");
    }
}
