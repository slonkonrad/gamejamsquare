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

    public float DEBUG_currentVelocity;
    void Move(Vector3 pos)
    {
        float lerpValue = ((myHuman.maxVelocity - myHuman.rb.velocity.magnitude) / myHuman.maxVelocity) * myHuman.acceleration;
        if (myHuman.rb.velocity.magnitude >= myHuman.maxVelocity)
            lerpValue = 1;

        Vector3 targetVector = myTarget.transform.position - myHuman.transform.position;
        myHuman.rb.velocity = Vector3.Normalize(targetVector) * Mathfx.Lerp(myHuman.rb.velocity.magnitude, myHuman.speed, lerpValue);
        myHuman.transform.rotation = Quaternion.LookRotation(targetVector);

        DEBUG_currentVelocity = myHuman.rb.velocity.magnitude;
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
