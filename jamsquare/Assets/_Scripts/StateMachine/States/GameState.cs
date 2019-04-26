using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : BaseState, IGameView, IScoreListener
{
    public override void InitState(GameController gameController)
    {
        base.InitState(gameController);
        this.gameController.UIController.GameUIController.GameView.listener = this;
        this.gameController.ScoreController.ScoreListener = this;
        gameController.UIController.GameUIController.GameView.ShowView();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        #region ScoreControllerTest

        if (Input.GetKeyDown(KeyCode.K))
        {
            gameController.ScoreController.NpcKilled("Player 1");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            gameController.ScoreController.ArrivedAtStation("Player 1", 5);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            gameController.ScoreController.StartLap("Player 1");
        }

        #endregion
    }

    public override void DeinitState()
    {
        base.DeinitState();
        gameController.UIController.GameUIController.GameView.HideView();
    }

    public void SetMenuState()
    {
        gameController.ChangeState(new MenuState());
    }

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
}
