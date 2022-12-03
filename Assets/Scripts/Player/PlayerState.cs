using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerState
{
    public Player player;

    public PlayerState(Player _player)
    {
        player = _player;
    }

    public virtual void enter() { }
    public virtual PlayerState handleInput(InputAction.CallbackContext context) { return this; }
    public virtual void update() { }
    public virtual void exit() { }
}
