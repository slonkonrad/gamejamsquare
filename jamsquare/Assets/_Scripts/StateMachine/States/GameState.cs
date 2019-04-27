using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : BaseState, IGameView, IActionButtons, IBumpers, ITriggers, ILeftAnalog, IRightAnalog, IScoreListener
{
    private InputController<BaseInput>.TriggerInput playerOneReceivedTriggerInput;
    private InputController<BaseInput>.TriggerInput playerTwoReceivedTriggerInput;

    private InputController<BaseInput>.LeftAnalogInput playerOneReceivedLeftAnalogInput;
    private InputController<BaseInput>.LeftAnalogInput playerTwoReceivedLeftAnalogInput;


    public override void InitState(GameController gameController)
    {
        base.InitState(gameController);
        this.gameController.UIController.GameUIController.GameView.listener = this;
        gameController.UIController.GameUIController.GameView.ShowView();
        this.gameController.ScoreController.ScoreListener = this;
        gameController.ScoreController.StartLap("Player 1");
        RegisterInputs();
        this.gameController.SoundController.playSound("SummerTown");
    }

    public override void UpdateState()
    {
        base.UpdateState();
        gameController.PlayerOneInputController.UpdateInputs();
        gameController.PlayerTwoInputController.UpdateInputs();
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
        gameController.PlayerOneCarController.UpdateCarPosition(playerOneReceivedTriggerInput, playerOneReceivedLeftAnalogInput);
        gameController.PlayerTwoCarController.UpdateCarPosition(playerTwoReceivedTriggerInput, playerTwoReceivedLeftAnalogInput);
    }

    public override void DeinitState()
    {
        base.DeinitState();
        gameController.UIController.GameUIController.GameView.HideView();
        UnregisterInputs();
        this.gameController.SoundController.stopSound("SummerTown");
    }

    public void SetMenuState()
    {
        gameController.ChangeState(new MenuState());
    }

    private void RegisterInputs()
    {
        this.gameController.UIController.GameUIController.GameView.listener = this;
        this.gameController.playerOneInputListener.RegisterActionButtons(this);
        this.gameController.playerTwoInputListener.RegisterActionButtons(this);
        this.gameController.playerOneInputListener.RegisterBumperButtons(this);
        this.gameController.playerTwoInputListener.RegisterBumperButtons(this);
        this.gameController.playerOneInputListener.RegisterTriggerButtons(this);
        this.gameController.playerTwoInputListener.RegisterTriggerButtons(this);
        this.gameController.playerOneInputListener.RegisterLeftAnalog(this);
        this.gameController.playerTwoInputListener.RegisterLeftAnalog(this);
        this.gameController.playerOneInputListener.RegisterRightAnalog(this);
        this.gameController.playerTwoInputListener.RegisterRightAnalog(this);
    }

    private void UnregisterInputs()
    {
        this.gameController.playerOneInputListener.UnregisterActionButtons();
        this.gameController.playerTwoInputListener.UnregisterActionButtons();
        this.gameController.playerOneInputListener.UnregisterBumperButtons();
        this.gameController.playerTwoInputListener.UnregisterBumperButtons();
        this.gameController.playerOneInputListener.UnregisterTriggerButtons();
        this.gameController.playerTwoInputListener.UnregisterTriggerButtons();
        this.gameController.playerOneInputListener.UnregisterLeftAnalog();
        this.gameController.playerTwoInputListener.UnregisterLeftAnalog();
        this.gameController.playerOneInputListener.UnregisterRightAnalog();
        this.gameController.playerTwoInputListener.UnregisterRightAnalog();
    }

    #region IActionButtons implementation
    public void A_ButtonInputReceived<T>(T player) where T : BaseInput
    {
        Debug.Log("A: " + player.PlayerID);
    }

    public void B_ButtonInputReceived<T>(T player) where T : BaseInput
    {
        Debug.Log("B: " + player.PlayerID);
    }

    public void X_ButtonInputReceived<T>(T player) where T : BaseInput
    {
        Debug.Log("X: " + player.PlayerID);
    }

    public void Y_ButtonInputReceived<T>(T player) where T : BaseInput
    {
        Debug.Log("Y: " + player.PlayerID);
    }
    #endregion

    #region IBumpers implementation
    public void LB_ButtonInputReceived<T>(T player) where T : BaseInput
    {
     //   Debug.Log("LB: " + player.PlayerID);
    }

    public void RB_ButtonInputReceived<T>(T player) where T : BaseInput
    {
     //   Debug.Log("RB: " + player.PlayerID);
    }
    #endregion

    #region ITriggers implementation
    public void UpdateTriggerInput<T>(InputController<T>.TriggerInput triggerInputReceived, T player) where T : BaseInput
    {
        if (player.PlayerID.Equals(Keys.Players.PLAYER_ONE))
        {
            playerOneReceivedTriggerInput.LT = triggerInputReceived.LT;
            playerOneReceivedTriggerInput.RT = triggerInputReceived.RT;
        }
        else
        {
            playerTwoReceivedTriggerInput.LT = triggerInputReceived.LT;
            playerTwoReceivedTriggerInput.RT = triggerInputReceived.RT;
        }
    }
    #endregion

    #region ILeftAnalog implementation
    public void UpdateLeftAnalogInput<T>(InputController<T>.LeftAnalogInput leftAnalogInputReceived, T player) where T : BaseInput
    {
        if (player.PlayerID.Equals(Keys.Players.PLAYER_ONE))
        {
            playerOneReceivedLeftAnalogInput.leftAnalogH = leftAnalogInputReceived.leftAnalogH;
            playerOneReceivedLeftAnalogInput.leftAnalogV = leftAnalogInputReceived.leftAnalogV;

            if (playerOneReceivedLeftAnalogInput.leftAnalogH > -1 && playerOneReceivedLeftAnalogInput.leftAnalogH < 1)
                playerOneReceivedLeftAnalogInput.leftAnalogH = 0;
        }
        else
        {
            playerTwoReceivedLeftAnalogInput.leftAnalogH = leftAnalogInputReceived.leftAnalogH;
            playerTwoReceivedLeftAnalogInput.leftAnalogV = leftAnalogInputReceived.leftAnalogV;
        }
    }
    #endregion

    #region IRightAnalog implementation
    public void UpdateRightAnalogInput<T>(InputController<T>.RightAnalogInput rightAnalogInputReceived, T player) where T : BaseInput
    {
        //Debug.Log("RightAnalogH: " + rightAnalogInputReceived.rightAnalogH + "|| player: " + player.PlayerID);
        //Debug.Log("RightAnalogV: " + rightAnalogInputReceived.rightAnalogV + "|| player: " + player.PlayerID);
    } 
    #endregion

    #region IScoreListener implementation

    public void UpdateScore(Score score)
    {
        this.gameController.UIController.GameUIController.GameView.UpdateScore(score);
    }

    public void NpcKilled(string playerName)
    {
        gameController.ScoreController.NpcKilled(playerName);
    }

    public void FinishedLap(string playerName, int numberOfNpcOnBoard)
    {
        gameController.ScoreController.ArrivedAtStation(playerName, numberOfNpcOnBoard);
    }

    #endregion
}
