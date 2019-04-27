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

    private float horizontalInput;
    private float verticalInput;
    private float steeringAngle;

    private void UpdateInputs(InputController<BaseInput>.TriggerInput receivedTriggerInput,
        InputController<BaseInput>.LeftAnalogInput receivedLeftAnalogInput)
    {
       
        if (receivedTriggerInput.RT > 0)
            verticalInput = receivedTriggerInput.RT;
        else if (receivedTriggerInput.LT > 0)
            verticalInput = -receivedTriggerInput.LT;
        
        horizontalInput = receivedLeftAnalogInput.leftAnalogH;
        Debug.Log(horizontalInput);
    }

    private void Steer()
    {
        steeringAngle = car.maxSteerAngle * horizontalInput;
        car.frontDriverWheel.steerAngle = steeringAngle;
        car.frontPassangerWheel.steerAngle = steeringAngle;
    }

    private void Accelerate()
    {
        car.frontDriverWheel.motorTorque = verticalInput * car.motorForce;
        car.frontPassangerWheel.motorTorque = verticalInput * car.motorForce;
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPosition(car.frontDriverWheel, car.frontDriverTransform);
        UpdateWheelPosition(car.frontPassangerWheel, car.frontPassangerTransform);
        UpdateWheelPosition(car.backDriverWheel, car.backDriverTransform);
        UpdateWheelPosition(car.backPassangerWheel, car.backPassangerTransform);
    }

    private void UpdateWheelPosition(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 tempPos = wheelTransform.position;
        Quaternion tempQuat = wheelTransform.rotation;

        wheelCollider.GetWorldPose(out tempPos, out tempQuat);

        wheelTransform.position = tempPos;
        wheelTransform.rotation = tempQuat;
    }

    public void UpdateCarPosition(InputController<BaseInput>.TriggerInput receivedTriggerInput,
        InputController<BaseInput>.LeftAnalogInput receivedLeftAnalogInput)
    {
        UpdateInputs(receivedTriggerInput, receivedLeftAnalogInput);
        Steer();
        Accelerate();
        UpdateWheelPoses();
    }
}
