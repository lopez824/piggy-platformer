using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggyState
{
    public PiggyAIController piggyController;
    
    public PiggyState(PiggyAIController controller)
    {
        piggyController = controller;
    }

    public virtual void enter() { }
    public virtual PiggyState handleEvent(string eventName) { return this; }
    public virtual void update() { }
    public virtual void exit() { }
}
