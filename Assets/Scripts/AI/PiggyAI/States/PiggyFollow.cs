using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggyFollow : PiggyState
{
    public PiggyFollow(PiggyAIController controller) : base(controller)
    {
        piggyController = controller;
    }

    public override void enter()
    {
        Debug.Log("Entered Follow State");
        piggyController.anim.SetTrigger("isWalking");

        // TODO: Implement Behavior Tree
    }

    public override PiggyState handleEvent(string name)
    {
        switch (name)
        {
            case "MoveCancel":
                return new PiggyIdle(piggyController);
            case "Jump":
                return new PiggyJump(piggyController);
        }

        return null;
    }

    public override void update()
    {
        piggyController.MoveTo(piggyController.player.transform.position);
    }

    public override void exit()
    {
        Debug.Log("Exited Follow State");
        piggyController.anim.ResetTrigger("isWalking");
    }
}
