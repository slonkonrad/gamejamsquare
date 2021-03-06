﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private int checkpointNumber;

    public int CheckpointNumber => checkpointNumber;

    public event Action<CheckPoint, PlayerCar> HandleCheckpoint = delegate { };

    public void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.transform.parent.GetComponent<PlayerCar>();
        if (player != null)
        {
            Debug.LogFormat("Player {0} entered checkpoint {1}", player.PlayerId, checkpointNumber);
            HandleCheckpoint(this, player);
        }
    }
}
