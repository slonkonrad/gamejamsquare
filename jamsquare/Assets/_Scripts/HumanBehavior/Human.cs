using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Human : MonoBehaviour
{
    public Rigidbody rb;
    public Transform model;
    public Target currentTarget;
    public Animator animator;
    [SerializeField]
    public float speed = 2;

    public bool hasAnimation = false;
    [SerializeField]
    public float maxVelocity;
    [SerializeField]
    public float acceleration;

    public BaseHState currentState;

    public void Initialise()
    {
        rb = GetComponent<Rigidbody>();
        currentState = new GoToTargetState();
        currentState.Initialise(this,currentTarget);
    }

    void FixedUpdate()
    {
        CustomFixedUpdate();
    }
    private void Update()
    {
        CustomUpdate();
    }
    void CustomFixedUpdate()
    {
        if(currentState!=null)
            currentState.FixedUpdateState();
    }
    void CustomUpdate()
    {
        if(currentState!=null)
            currentState.UpdateState();
    }

    public void SetGoToTargetState(Target target, float waitTime)
    {
        currentState.Deinitialise();
        currentState = new GoToTargetState();
        currentState.myWaitTime = waitTime;
        currentState.Initialise(this, target);
        
    }
    public void SetWaitState(Target target, float waitTime)
    {
        currentState.Deinitialise();
        currentState = new WaitState();
        currentState.myWaitTime = waitTime;
        currentState.Initialise(this, target);
    }

}
