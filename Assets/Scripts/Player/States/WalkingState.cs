using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WalkingState : PlayerState
{
    public WalkingState(Player _player) : base(_player)
    {
        player = _player;
    }

    public override void enter()
    {
        //Debug.Log("Enter Walk");
        player.anim.SetTrigger("isWalking");
        
    }

    public override PlayerState handleInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            switch (context.action.name)
            {
                case "Move":
                    update();
                    break;
                case "Attack":
                    return new AttackState(player);
                case "Jump":
                    return new JumpState(player);
            }
        }

        if (context.canceled)
            return new IdleState(player);

        return null;
    }

    public override void update()
    {
        //Debug.Log("Walking!");
    }

    public override void exit()
    {
        //Debug.Log("Exit Walk");
        player.anim.ResetTrigger("isWalking");
    }
}
