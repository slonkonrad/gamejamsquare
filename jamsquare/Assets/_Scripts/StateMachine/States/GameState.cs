using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : BaseState, IGameView
{
    public override void InitState(GameController gameController)
    {
        base.InitState(gameController);
        this.gameController.UIController.GameUIController.GameView.listener = this;
        gameController.UIController.GameUIController.GameView.ShowView();
    }

    public override void UpdateState()
    {
        base.UpdateState();
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
}
