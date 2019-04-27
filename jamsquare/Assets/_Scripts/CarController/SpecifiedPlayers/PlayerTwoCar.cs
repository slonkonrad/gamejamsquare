using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoCar : CarController<BaseCar>
{
    [SerializeField] private BaseCar baseCar;

    private void Awake()
    {
        SetCar(baseCar);
    }
}
