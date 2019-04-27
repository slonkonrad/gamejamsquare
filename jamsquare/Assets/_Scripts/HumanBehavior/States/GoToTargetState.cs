using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTargetState : BaseHState
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
        GoToTarget();

    }


    public override void UpdateState()
    {
        ChangeTarget();
    }

    void GoToTarget()
    {
        Vector3 pos = myTarget.transform.position;
        Move(pos);
        Debug.DrawLine(myHuman.transform.position, pos, Color.red);
    }

    void Move(Vector3 pos)
    {
        float velocityMagnitude = myHuman.rb.velocity.magnitude;
        float lerpValue = ((myHuman.maxVelocity - velocityMagnitude) / myHuman.maxVelocity) * myHuman.acceleration;
        if ( velocityMagnitude >= myHuman.maxVelocity)
            lerpValue = 1;

        Vector3 targetVector = myTarget.transform.position - myHuman.transform.position;
        myHuman.rb.velocity = Vector3.Normalize(targetVector) * myHuman.speed;
        myHuman.model.rotation = Quaternion.LookRotation(targetVector);

    }

    void Animate()
    {
        if (!myHuman.hasAnimation)
        {
            myHuman.animator.SetTrigger(Keys.Animations.RUN_ANIMATIONS[Random.Range(0, Keys.Animations.RUN_ANIMATIONS.Length)]);
            myHuman.hasAnimation = true;
        }
    }


    void ChangeTarget()
    {
        if (Vector3.Distance(myTarget.transform.position, myHuman.transform.position) < myTarget.range)
                myHuman.currentTarget = myTarget.GetNextTarget(myHuman);
    }










    public override void Deinitialise()
    {
    }
}
