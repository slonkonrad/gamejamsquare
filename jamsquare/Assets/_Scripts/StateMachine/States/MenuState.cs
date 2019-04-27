using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : BaseState, IMenuView, IActionButtons, ILeftAnalog, IPlayerSelectionView
{
    private InputController<BaseInput>.LeftAnalogInput playerOneReceivedLeftAnalogInput;

    public override void InitState(GameController gameController)
    {
        base.InitState(gameController);
        this.gameController.UIController.MenuUIController.PlayerSelectionView.listener = this;
        this.gameController.UIController.MenuUIController.MenuView.listener = this;
        this.gameController.playerOneInputListener.RegisterActionButtons(this);
        this.gameController.playerOneInputListener.RegisterLeftAnalog(this);
        this.gameController.UIController.MenuUIController.CurrentView = this.gameController.UIController.MenuUIController.MenuView;
        this.gameController.UIController.MenuUIController.CurrentView.ShowView();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        gameController.UIController.MenuUIController.CurrentView.SwitchButtonFocus(playerOneReceivedLeftAnalogInput);
        gameController.PlayerOneInputController.UpdateInputs();
    }

    public override void DeinitState()
    {
        base.DeinitState();
        this.gameController.playerOneInputListener.UnregisterActionButtons();
        this.gameController.playerOneInputListener.UnregisterLeftAnalog();
        this.gameController.UIController.MenuUIController.CurrentView.HideView();
    }

    #region IMenuView implementation

    public void SetGameState()
    {
        gameController.ChangeState(new GameState());
    }

    public void OnStartButtonFocused()
    {
        this.gameController.UIController.MenuUIController.CurrentView.HideView();
        this.gameController.UIController.MenuUIController.SetActiveView(gameController.UIController.MenuUIController.PlayerSelectionView);
        this.gameController.UIController.MenuUIController.CurrentView.ShowView();
    }

    public void OnExitButtonFocused()
    {
        Application.Quit();
    }
    #endregion

    #region IActionButtons implementation
    public void A_ButtonInputReceived<T>(T player) where T : BaseInput
    {
        gameController.UIController.MenuUIController.CurrentView.ExecuteFocusedButton(player);
    }

    public void B_ButtonInputReceived<T>(T player) where T : BaseInput
    {

    }

    public void X_ButtonInputReceived<T>(T player) where T : BaseInput
    {

    }

    public void Y_ButtonInputReceived<T>(T player) where T : BaseInput
    {

    }

    public void UpdateLeftAnalogInput<T>(InputController<T>.LeftAnalogInput leftAnalogInputReceived, T player) where T : BaseInput
    {
        playerOneReceivedLeftAnalogInput.leftAnalogH = leftAnalogInputReceived.leftAnalogH;
        playerOneReceivedLeftAnalogInput.leftAnalogV = leftAnalogInputReceived.leftAnalogV;

        if (playerOneReceivedLeftAnalogInput.leftAnalogV > -1 && playerOneReceivedLeftAnalogInput.leftAnalogV < 1)
            playerOneReceivedLeftAnalogInput.leftAnalogV = 0;

        if (playerOneReceivedLeftAnalogInput.leftAnalogH > -1 && playerOneReceivedLeftAnalogInput.leftAnalogH < 1)
            playerOneReceivedLeftAnalogInput.leftAnalogH = 0;
    }

    #endregion

    #region IPlayerSelectionView implementation

    public void OnSingleplayerButtonFocused()
    {
        gameController.UIController.MenuUIController.PlayerSelectionView.SwitchToSingleplayerView();
    }

    public void OnMultiplayerButtonFocused()
    {
        gameController.UIController.MenuUIController.PlayerSelectionView.SwitchToMultiplayerView();
    }

    #endregion

}
