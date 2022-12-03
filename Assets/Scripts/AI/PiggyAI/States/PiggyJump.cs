using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggyJump : PiggyState
{
    public PiggyJump(PiggyAIController controller) : base(controller)
    {
        piggyController = controller;
    }

    public override void enter()
    {
        //Debug.Log("Entered Jump State");
        piggyController.anim.SetTrigger("isJumping");
        piggyController.sound.PlayOneShot(AudioLibrary.library[piggyController.oinkName]);

        // TODO: Implement Behavior Tree
    }

    public override PiggyState handleEvent(string name)
    {
        return null;
    }

    public override void update()
    {
        piggyController.MoveTo(piggyController.player.transform.position);
    }

    public override void exit()
    {
        //Debug.Log("Exited Jump State");
        piggyController.anim.ResetTrigger("isJumping");
    }
}
