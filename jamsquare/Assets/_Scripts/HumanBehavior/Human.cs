using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    Rigidbody rb;
    Transform target;

    void Start()
    {
        Initialise();
    }
    void Initialise()
    {
        rb.GetComponent<Rigidbody>();
    }

    void Update()
    {
        CustomUpdate();
    }
    void CustomUpdate()
    {

    }

    void GoToTarget()
    {

    }

    void Move(Transform target)
    {
        rb.AddForce(transform.position - target.position);
    }

}
