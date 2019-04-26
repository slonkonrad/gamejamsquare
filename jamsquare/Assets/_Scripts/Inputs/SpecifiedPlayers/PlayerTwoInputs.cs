using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoInputs : InputController<BaseInput>
{
    [SerializeField] private BaseInput baseInput;

    private void Awake()
    {
        SetPlayer(baseInput);
    }
}
