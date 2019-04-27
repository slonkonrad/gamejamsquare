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
    }

    public override void FixedUpdateState()
    {
        throw new System.NotImplementedException();
    }


    public override void UpdateState()
    {
        throw new System.NotImplementedException();
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
