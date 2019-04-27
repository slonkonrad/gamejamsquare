using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuView : BaseView
{
    public IMenuView listener;

    enum MenuButton { start, exit }

    #region init
    List<MenuButton> buttonsType = new List<MenuButton>();
    private void Awake()
    {
        buttonsType.Add(MenuButton.start);
        buttonsType.Add(MenuButton.exit);
    }
    #endregion

    [SerializeField] MenuButton focusedButton;

    [SerializeField] Color defaultButtonColor;
    [SerializeField] Color focusButtonColor;

    [SerializeField] Image startButton;
    [SerializeField] Image exitButton;

    private bool negativeClicked = false;
    private bool positiveClicked = false;

    public override void ShowView()
    {
        base.ShowView();
        FocusButton(MenuButton.start);
    }

    public override void HideView()
    {
        base.HideView();
    }

    public override void SwitchButtonFocus<T>(InputController<T>.LeftAnalogInput leftAnalogInputReceived)
    {
        if (leftAnalogInputReceived.leftAnalogV > 0)
        {
            StartCoroutine(FocusPreviousButton(leftAnalogInputReceived));
        }
        else if (leftAnalogInputReceived.leftAnalogV < 0)
        {
            StartCoroutine(FocusNextButton(leftAnalogInputReceived));
        }
    }

    public override void ExecuteFocusedButton<T>(T player)
    {
        switch (focusedButton)
        {
            case MenuButton.start:
                listener.OnStartButtonFocused();
                break;
            case MenuButton.exit:
                listener.OnExitButtonFocused();
                break;
        }
    }

    void RestartButtons()
    {
        startButton.color = defaultButtonColor;
        exitButton.color = defaultButtonColor;
    }

    void FocusButton(MenuButton button)
    {
        RestartButtons();
        switch (button)
        {
            case MenuButton.start:
                startButton.color = focusButtonColor;
                break;
            case MenuButton.exit:
                exitButton.color = focusButtonColor;
                break;
        }
    }

    IEnumerator FocusNextButton<T>(InputController<T>.LeftAnalogInput leftAnalogInputReceived) where T : BaseInput
    {
        if (!negativeClicked)
        {
            leftAnalogInputReceived.leftAnalogV = 0;
            int index = buttonsType.IndexOf(focusedButton);
            index++;
            if (index.Equals(buttonsType.Count))
                index = 0;
            focusedButton = buttonsType[index];
            FocusButton(focusedButton);
            negativeClicked = true;

            yield return new WaitForSeconds(.15f);
            negativeClicked = false;
        }
    }

    IEnumerator FocusPreviousButton<T>(InputController<T>.LeftAnalogInput leftAnalogInputReceived) where T:BaseInput
    {
        if (!positiveClicked)
        {
            leftAnalogInputReceived.leftAnalogV = 0;
            int index = buttonsType.IndexOf(focusedButton);
            index--;
            if (index < 0)
                index = buttonsType.Count - 1;
            focusedButton = buttonsType[index];
            FocusButton(focusedButton);
            positiveClicked = true;

            yield return new WaitForSeconds(.15f);
            positiveClicked = false;
        }
    }
}
