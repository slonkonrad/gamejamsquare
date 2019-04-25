using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameUIController gameUIController;
    public GameUIController GameUIController => gameUIController;

    [SerializeField] private MenuUIController menuUIController;
    public MenuUIController MenuUIController => menuUIController;
}
