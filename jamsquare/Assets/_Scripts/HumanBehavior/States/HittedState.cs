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
        myHuman.gameObject.tag = "Body";
        myHuman.animator.enabled = false;
        myHuman.rb.constraints = RigidbodyConstraints.None;
        myHuman.PlayParticle();
        //myHuman.Hide();


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
