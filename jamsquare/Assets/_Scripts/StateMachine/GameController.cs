using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private UIController uiController;
    public UIController UIController => uiController;

    [SerializeField]
    private ScoreController scoreController;
    public ScoreController ScoreController => scoreController;

    private void Awake()
    {
        Initialization();
    }

    private void Initialization()
    {
        ChangeState(new MenuState());
    }

    private BaseState currentState;

    public void ChangeState(BaseState newState)
    {
        if (currentState != null)
            currentState.DeinitState();

        currentState = newState;

        if (currentState != null)
            currentState.InitState(this);
    }

    public void Update()
    {
        if (currentState != null)
            currentState.UpdateState();
    }
}
