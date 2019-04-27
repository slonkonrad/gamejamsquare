using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform car;
    public void UpdateCarPosition<T>(T player, InputController<T>.LeftAnalogInput leftAnalogInputReceived) where T:BaseInput
    {
        
    }
}
