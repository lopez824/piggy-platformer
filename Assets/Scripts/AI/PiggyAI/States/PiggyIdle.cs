using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggyIdle : PiggyState
{
    public PiggyIdle(PiggyAIController controller) : base (controller)
    {
        piggyController = controller;
    }

    public override void enter()
    {
        Debug.Log("Entered Idle State");
        piggyController.anim.SetTrigger("isIdle");

        // TODO: Implement Behavior Tree
    }

    public override PiggyState handleEvent(string name)
    {
        switch (name)
        {
            case "Move":
                return new PiggyFollow(piggyController);
            case "Jump":
                return new PiggyJump(piggyController);
        }

        return null;
    }

    public override void update()
    {
        if (piggyController.GetDistanceTo(piggyController.player.transform.position) > 3f)
            piggyController.ChangeState("Move");
    }

    public override void exit()
    {
        Debug.Log("Exited Idle State");
        piggyController.anim.ResetTrigger("isIdle");
    }
}
