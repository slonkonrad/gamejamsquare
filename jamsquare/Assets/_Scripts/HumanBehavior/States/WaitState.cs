using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitState : BaseHState
{
    Human myHuman;
    Target myTarget;
    public override void Initialise(Human human, Target target)
    {
        myHuman = human;
        myTarget = target;

        Animate();
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
        myHuman.currentTarget = myTarget.GetNextTarget(myHuman);
    }

    void Animate()
    {
        if (myTarget.isStartTarget)
            myHuman.animator.SetTrigger(Keys.Animations.IDLE_ANIMATIONS[Random.Range(0, Keys.Animations.IDLE_ANIMATIONS.Length)]);
    }
    public override void Deinitialise()
    {
        throw new System.NotImplementedException();
    }
}
