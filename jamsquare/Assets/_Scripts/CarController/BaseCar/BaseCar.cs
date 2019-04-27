using UnityEngine;

[System.Serializable]
public class BaseCar
{
    public float groundedDrag = 3f;
    public float maxVelocity = 50;
    public float hoverForce = 1000;
    public float gravityForce = 1000f;
    public float hoverHeight = 1.5f;
    public float forwardAcceleration = 8000f;
    public float reverseAcceleration = 4000f;
    public float turnStrength = 1000f;
    public Transform carT;
    public GameObject[] hoverPoints;
    public Rigidbody carRB;
}
