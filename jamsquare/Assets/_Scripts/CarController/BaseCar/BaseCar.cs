using UnityEngine;

[System.Serializable]
public class BaseCar
{
    public WheelCollider frontDriverWheel, frontPassangerWheel;
    public WheelCollider backDriverWheel, backPassangerWheel;
    public Transform frontDriverTransform, frontPassangerTransform;
    public Transform backDriverTransform, backPassangerTransform;
    public float maxSteerAngle = 30;
    public float motorForce = 200;
}
