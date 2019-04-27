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
        StopAnimation();
        AnimateIdle();
        checkingTime = true;
    }
    float timer = 0;
    bool checkingTime;
    bool timerDone;

    public override void FixedUpdateState()
    {

        if (checkingTime)
        {
            timer += Time.deltaTime;
            if (timer >= myWaitTime
                )
            {
                timerDone = true;
                checkingTime = false;
                timer = 0;
            StopAnimation();
            Animate();
            }
        }

        if (timerDone)
        {
            //DoSomething()
        GoToTarget();
        }

    }


    public override void UpdateState()
    {
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
            int animNumber = Random.Range(0, Keys.Animations.RUN_ANIMATIONS.Length);
            myHuman.animator.SetTrigger(Keys.Animations.RUN_ANIMATIONS[animNumber]);
            myHuman.speed = Keys.Animations.RUN_ANIMARIONS_SPEED[animNumber];
            myHuman.hasAnimation = true;
        }
    }
    void StopAnimation()
    {
        myHuman.hasAnimation = false;
        myHuman.animator.SetTrigger(Keys.Animations.STOP_ANIMATIONS);

    }
    void AnimateIdle()
    {
        if (!myHuman.hasAnimation)
        {
            myHuman.animator.SetTrigger(Keys.Animations.IDLE_ANIMATIONS[Random.Range(0, Keys.Animations.IDLE_ANIMATIONS.Length)]);
            myHuman.hasAnimation = true;
        }
    }


    public override void ChangeTarget()
    {
                myHuman.currentTarget = myTarget.GetNextTarget(myHuman);
    }










    public override void Deinitialise()
    {
    }
}
