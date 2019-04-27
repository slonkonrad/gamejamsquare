using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneCar : CarController<BaseCar>
{
    [SerializeField] private BaseCar baseCar;

    private void Awake()
    {
        SetCar(baseCar);
    }

    public float GetRBLocalVelocityMagnitude()
    {
        return transform.InverseTransformDirection(baseCar.carRB.velocity).magnitude;
        // or return transform.InverseTransformDirection(baseCar.carRB.velocity).x;
    }
}
