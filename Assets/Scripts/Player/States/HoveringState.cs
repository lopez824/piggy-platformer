using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HoveringState : PlayerState
{
    public HoveringState(Player _player) : base(_player)
    {
        player = _player;
    }

    public override void enter()
    {
        //Debug.Log("Enter Hover");
    }

    public override PlayerState handleInput(InputAction.CallbackContext context)
    {
        if (context.action.name == "Jump")
            if (context.canceled)
                return new IdleState(player);

        return null;
    }

    public override void update()
    {
        base.update();
    }

    public override void exit()
    {
        //Debug.Log("Exit Hover");
    }
}
