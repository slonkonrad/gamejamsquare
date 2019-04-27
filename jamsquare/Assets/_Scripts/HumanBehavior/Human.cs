using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Human : MonoBehaviour
{
    public Rigidbody rb;
    public Transform model;
    public Target currentTarget;
    [SerializeField]
    public float speed = 2;

    public float startRandomValue = 10;

    [SerializeField]
    public float maxVelocity;
    [SerializeField]
    public float acceleration;

    BaseHState currentState;

    public void Initialise()
    {
        rb = GetComponent<Rigidbody>();
        if (!currentTarget.isStartTarget)
            Debug.Log("to niee jest startowy target");
        startRandomValue = Random.Range(0, 10);
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
        currentState.FixedUpdateState();
    }
    void CustomUpdate()
    {
        currentState.UpdateState();
    }

    public void SetGoToTargetState(Target target)
    {
            currentState.Deinitialise();
            currentState = new GoToTargetState();
            currentState.Initialise(this, target);
        
    }








}
