using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackState : PlayerState
{
    public AttackState(Player _player) : base(_player)
    {
        player = _player;
    }

    public override void enter()
    {
        //Debug.Log("Enter Attack");
        player.sound.PlayOneShot(AudioLibrary.library["oink_1"]);
    }

    public override PlayerState handleInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            switch (context.action.name)
            {
                case "Attack":
                    update();
                    break;
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
        //Debug.Log("Attack!");
        player.sound.PlayOneShot(AudioLibrary.library["oink_1"]);
    }

    public override void exit()
    {
        //Debug.Log("Exit Attack");
    }
}
