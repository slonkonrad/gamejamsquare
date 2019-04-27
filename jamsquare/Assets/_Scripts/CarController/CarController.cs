using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController<T> : MonoBehaviour where T : BaseCar
{
    private T car;

    public void SetCar(T car)
    {
        this.car = car;
    }
    private Rigidbody body;
    private float deadZone = 0.1f;
    private float thrust = 0f;

    private float turnValue = 0f;

    private int layerMask;

    void Start()
    {
        body = car.carRB;
        body.centerOfMass = Vector3.down;

        layerMask = 512;
        layerMask = ~layerMask;
    }

    public void UpdateInputs(InputController<BaseInput>.TriggerInput receivedTriggerInput,
       InputController<BaseInput>.LeftAnalogInput receivedLeftAnalogInput)
    {
        thrust = 0.0f;
        float acceleration = 0;
        if (receivedTriggerInput.RT > deadZone)
        {
            acceleration = receivedTriggerInput.RT;
            thrust = acceleration * car.forwardAcceleration;
        }
        else if (receivedTriggerInput.LT > deadZone)
        {
            acceleration = -receivedTriggerInput.LT;
            thrust = acceleration * car.reverseAcceleration;
        }

        turnValue = 0.0f;
        float turnAxis = receivedLeftAnalogInput.leftAnalogH;
        if (Mathf.Abs(turnAxis) > deadZone)
            turnValue = turnAxis;

        if (acceleration < 0)
            turnValue = -turnValue;
    }

    public void UpdatePhysicsCalculation()
    {
        RaycastHit hit;
        bool grounded = false;
        for (int i = 0; i < car.hoverPoints.Length; i++)
        {
            var hoverPoint = car.hoverPoints[i];
            if (Physics.Raycast(hoverPoint.transform.position, -Vector3.up, out hit, car.hoverHeight, layerMask))
            {
                body.AddForceAtPosition(Vector3.up * car.hoverForce * (1.0f - (hit.distance / car.hoverHeight)), hoverPoint.transform.position);
                grounded = true;
            }
            else
            {
                if (car.carT.position.y > hoverPoint.transform.position.y)
                {
                    body.AddForceAtPosition(hoverPoint.transform.up * car.gravityForce, hoverPoint.transform.position);
                }
                else
                {
                    body.AddForceAtPosition(hoverPoint.transform.up * -car.gravityForce, hoverPoint.transform.position);
                }
            }
        }

        if (grounded)
        {
            body.drag = car.groundedDrag;
        }
        else
        {
            body.drag = 0.1f;
            thrust /= 100f;
            turnValue /= 100f;
        }

        if (Mathf.Abs(thrust) > 0)
        {
            body.AddForce(car.carT.forward * thrust);
        }
            

        if (turnValue > 0)
        {
            body.AddRelativeTorque(Vector3.up * turnValue * car.turnStrength);
        }
        else if (turnValue < 0)
        {
            body.AddRelativeTorque(Vector3.up * turnValue * car.turnStrength);
        }

        if (body.velocity.sqrMagnitude > (body.velocity.normalized * car.maxVelocity).sqrMagnitude)
        {
            body.velocity = body.velocity.normalized * car.maxVelocity;
        }
    }
}
