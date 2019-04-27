using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public IInuptController playerOneInputListener;
    public IInuptController playerTwoInputListener;

    [SerializeField] private UIController uiController;
    public UIController UIController => uiController;

    [SerializeField] private PlayerOneInputs playerOneInputController;
    public PlayerOneInputs PlayerOneInputController => playerOneInputController;

    [SerializeField] private PlayerTwoInputs playerTwoInputController;
    public PlayerTwoInputs PlayerTwoInputController => playerTwoInputController;

    [SerializeField] private PlayerOneCar playerOneCarController;
    public PlayerOneCar PlayerOneCarController => playerOneCarController;

    [SerializeField] private PlayerTwoCar playerTwoCarController;
    public PlayerTwoCar PlayerTwoCarController => playerTwoCarController;

    [SerializeField] private ScoreController scoreController;
    public ScoreController ScoreController => scoreController;

    [SerializeField] 
    private ParticleController particleController;
    public ParticleController ParticleController => particleController;

    [SerializeField] 
    private SoundController soundController;
    public SoundController SoundController => soundController;

    [SerializeField]
    private PathController pathController;
    public PathController PathController => pathController;

    private void Awake()
    {
        Initialization();
    }
    
    private void Initialization()
    {
        playerOneInputListener = PlayerOneInputController;
        playerTwoInputListener = PlayerTwoInputController;
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

    private void FixedUpdate()
    {
        if (currentState != null)
            currentState.FixedUpdateState();
    }
}
