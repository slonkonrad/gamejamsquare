using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
    [SerializeField] private GameView gameView;
    public GameView GameView => gameView;
}
