using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpState : PlayerState
{
    public JumpState(Player _player) : base(_player)
    {
        player = _player;
    }

    public override void enter()
    {
        //Debug.Log("Enter Jump");
        player.anim.SetTrigger("isJumping");
        player.sound.PlayOneShot(AudioLibrary.library["oink_3"]);
    }

    public override PlayerState handleInput(InputAction.CallbackContext context)
    {
        if (context.action.name == "Jump")
            if (context.performed && player.isGrounded == false)
                return new HoveringState(player);
        
        return null;
    }

    public override void update()
    {
        base.update();
    }

    public override void exit()
    {
        //Debug.Log("Exit Jump");
        player.anim.ResetTrigger("isJumping");
    }
}
