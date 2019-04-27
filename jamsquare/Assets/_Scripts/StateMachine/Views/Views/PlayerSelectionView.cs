using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectionView : BaseView
{

    public IPlayerSelectionView listener;
    enum PlayerSelectionButton { singleplayer, multiplayer }

    [SerializeField] private GameObject singleplayerView;
    [SerializeField] private GameObject multiplayerView;

    [SerializeField] private Image playerOneImage;
    [SerializeField] private Image playerTwoImage;
    [SerializeField] private Text playerOneText;
    [SerializeField] private Text playerTwoText;

    bool singlePlayerOneReady = false;
    bool multiPlayerOneReady = false;
    bool multiPlayerTwoReady = false;


    public void SwitchToSingleplayerView()
    {
        singleplayerView.SetActive(true);
        multiplayerView.SetActive(false);
    }

    public void SwitchToMultiplayerView()
    {
        singleplayerView.SetActive(false);
        multiplayerView.SetActive(true);
    }

    #region init
    List<PlayerSelectionButton> buttonsType = new List<PlayerSelectionButton>();
    private void Awake()
    {
        buttonsType.Add(PlayerSelectionButton.singleplayer);
        buttonsType.Add(PlayerSelectionButton.multiplayer);
    }
    #endregion

    [SerializeField] PlayerSelectionButton focusedButton;

    [SerializeField] Color defaultButtonColor;
    [SerializeField] Color focusButtonColor;

    [SerializeField] Image singleplayerButton;
    [SerializeField] Image multiplayerButton;

    private bool negativeClicked = false;
    private bool positiveClicked = false;

    public override void ShowView()
    {
        base.ShowView();
        FocusButton(PlayerSelectionButton.singleplayer);
        Execute();
    }

    public override void HideView()
    {
        base.HideView();
    }

    public override void SwitchButtonFocus<T>(InputController<T>.LeftAnalogInput leftAnalogInputReceived)
    {
        if (leftAnalogInputReceived.leftAnalogH > 0)
        {
            StartCoroutine(FocusPreviousButton(leftAnalogInputReceived));
        }
        else if (leftAnalogInputReceived.leftAnalogH < 0)
        {
            StartCoroutine(FocusNextButton(leftAnalogInputReceived));
        }
    }

    public void Execute()
    {
        switch (focusedButton)
        {
            case PlayerSelectionButton.singleplayer:
                listener.OnSingleplayerButtonFocused();
                break;
            case PlayerSelectionButton.multiplayer:
                listener.OnMultiplayerButtonFocused();
                break;
        }
    }

    public override void ExecuteFocusedButton<T>(T player)
    {
        if (focusedButton.Equals(PlayerSelectionButton.singleplayer))
        {
            listener.SetGameState();
        }
        else if (focusedButton.Equals(PlayerSelectionButton.multiplayer))
        {
            if (player.PlayerID.Equals(Keys.Players.PLAYER_ONE))
            {
                multiPlayerOneReady = true;
                playerOneImage.color = Color.green;
                playerOneText.text = "READY!";
            }

            if (player.PlayerID.Equals(Keys.Players.PLAYER_TWO))
            {
                multiPlayerTwoReady = true;
                playerTwoImage.color = Color.green;
                playerTwoText.text = "READY!";
            }

            if (multiPlayerOneReady && multiPlayerTwoReady)
                listener.SetGameState();
        }

        
    }

    void RestartButtons()
    {
        singleplayerButton.color = defaultButtonColor;
        multiplayerButton.color = defaultButtonColor;
    }

    void FocusButton(PlayerSelectionButton button)
    {
        RestartButtons();
        switch (button)
        {
            case PlayerSelectionButton.singleplayer:
                singleplayerButton.color = focusButtonColor;
                break;
            case PlayerSelectionButton.multiplayer:
                multiplayerButton.color = focusButtonColor;
                break;
        }
    }

    IEnumerator FocusNextButton<T>(InputController<T>.LeftAnalogInput leftAnalogInputReceived) where T : BaseInput
    {
        if (!negativeClicked)
        {
            leftAnalogInputReceived.leftAnalogH = 0;
            int index = buttonsType.IndexOf(focusedButton);
            index++;
            if (index.Equals(buttonsType.Count))
                index = 0;
            focusedButton = buttonsType[index];
            FocusButton(focusedButton);
            negativeClicked = true;
            Execute();

            yield return new WaitForSeconds(.15f);
            negativeClicked = false;
        }
    }

    IEnumerator FocusPreviousButton<T>(InputController<T>.LeftAnalogInput leftAnalogInputReceived) where T : BaseInput
    {
        if (!positiveClicked)
        {
            leftAnalogInputReceived.leftAnalogH = 0;
            int index = buttonsType.IndexOf(focusedButton);
            index--;
            if (index < 0)
                index = buttonsType.Count - 1;
            focusedButton = buttonsType[index];
            FocusButton(focusedButton);
            positiveClicked = true;
            Execute();

            yield return new WaitForSeconds(.15f);
            positiveClicked = false;
        }
    }
}
