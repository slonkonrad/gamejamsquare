using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittedState : BaseHState
{
    Human myHuman;
    Target myTarget;
    public override void Initialise(Human human, Target target)
    {
        myHuman = human;
        myTarget = target;

        ChangeTarget();

    }


    public override void FixedUpdateState()
    {
    }

    public override void UpdateState()
    {

    }
    public override void ChangeTarget()
    {
    }


    public override void Deinitialise()
    {
    }
}
