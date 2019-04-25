using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : BaseState, IMenuView
{
    public override void InitState(GameController gameController)
    {
        base.InitState(gameController);
        this.gameController.UIController.MenuUIController.MenuView.listener = this;
        gameController.UIController.MenuUIController.MenuView.ShowView();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void DeinitState()
    {
        gameController.UIController.MenuUIController.MenuView.HideView();
        base.DeinitState();
    }

    #region IMenuView implementation
    public void SetGameState()
    {
        gameController.ChangeState(new GameState());
    } 
    #endregion
}
