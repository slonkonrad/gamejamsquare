using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Human : MonoBehaviour
{
    Rigidbody rb;
    public Target currentTarget;
    [SerializeField]
    private float speed = 2;

    public float StartRandomValue = 10;

    

    void Start()
    {
        Initialise();
    }
    void Initialise()
    {
        rb = GetComponent<Rigidbody>();
        if (!currentTarget.isStartTarget)
            Debug.Log("to niee jest startowy target");

    }

    void FixedUpdate()
    {
        CustomFixedUpdate();
    }
    void CustomFixedUpdate()
    {
        GoToTarget(currentTarget.transform);
        if (Vector3.Distance(transform.position, currentTarget.transform.position) < currentTarget.range)
            if (currentTarget.GetNextTarget() != null)
            currentTarget = currentTarget.GetNextTarget();

    }

    void GoToTarget(Transform target)
    {
        Vector3 pos = target.position;
        Move(pos);
        Debug.DrawLine(transform.position, target.transform.position,Color.red);
    }

    [SerializeField]
    private float maxVelocity;
    [SerializeField]
    private float acceleration;

    public float DEBUG_currentVelocity;
    void Move(Vector3 target)
    {
        //rb.velocity += (target - transform.position) * speed*Time.fixedDeltaTime;
        float lerpValue = ((maxVelocity - rb.velocity.magnitude) / maxVelocity) * acceleration;
        if (rb.velocity.magnitude >= maxVelocity)
            lerpValue = 1;
        rb.velocity = Vector3.Normalize((target - transform.position) )* Mathfx.Lerp(rb.velocity.magnitude, speed, lerpValue);
        DEBUG_currentVelocity = rb.velocity.magnitude;
    }



}
