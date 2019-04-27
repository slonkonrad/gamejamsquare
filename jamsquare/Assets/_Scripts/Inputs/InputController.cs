using UnityEngine;

public class InputController<T> : MonoBehaviour, IInuptController where T : BaseInput
{
    #region Interfaces
    public ILeftAnalog leftAnalogListener;
    public IRightAnalog rightAnalogListener;
    public IActionButtons actionButtonsListener;
    public IBumpers bumpersListener;
    public ITriggers triggersListener;
    #endregion

    private T player;
    private const int NO_ACTION = 0;

    protected void SetPlayer(T player)
    {
        this.player = player;
    }

    public struct TriggerInput
    {
        public float LT;
        public float RT;
    }

    public struct LeftAnalogInput
    {
        public float leftAnalogH;
        public float leftAnalogV;
    }

    public struct RightAnalogInput
    {
        public float rightAnalogH;
        public float rightAnalogV;
    }

    private LeftAnalogInput leftAnalogInputReceived;
    private RightAnalogInput rightAnalogInputReceived;
    private TriggerInput triggerInputReceived;

    #region variables
    private float A_Button = 0;
    private bool A_ButtonIsDown = false;

    private float B_Button = 0;
    private bool B_ButtonIsDown = false;

    private float X_Button = 0;
    private bool X_ButtonIsDown = false;

    private float Y_Button = 0;
    private bool Y_ButtonIsDown = false;

    private float LB_Button = 0;
    private bool LB_ButtonIsDown = false;

    private float RB_Button = 0;
    private bool RB_ButtonIsDown = false;

    private float leftTrigger = 0;
    private bool leftTriggerIsDown = false;

    private float rightTrigger = 0;
    private bool rightTriggerIsDown = false;
    #endregion

    public void UpdateInputs()
    {
        if (leftAnalogListener != null) UpdateLeftAnalogAxis(player);
        if (rightAnalogListener != null) UpdateRightAnalogAxis(player);
        if (actionButtonsListener != null) UpdateActionButtonsAxis(player);
        if (bumpersListener != null) UpdateBumperButtonsAxis(player);
        if (triggersListener != null) UpdateTriggersButtonsAxis(player);
    }

    private void UpdateLeftAnalogAxis(T player)
    {
        UpdateLeftAnalogInput(player);
    }

    #region RightAnalogAxis
    private void UpdateRightAnalogInput(T player)
    {
        rightAnalogInputReceived.rightAnalogH = Input.GetAxisRaw(Keys.Inputs.RIGHTANALOG_H[player.PlayerID]);
        rightAnalogInputReceived.rightAnalogV = Input.GetAxisRaw(Keys.Inputs.RIGHTANALOG_V[player.PlayerID]);
        rightAnalogListener.UpdateRightAnalogInput(rightAnalogInputReceived, player);
    } 
    #endregion

    private void UpdateRightAnalogAxis(T player)
    {
        UpdateRightAnalogInput(player);
    }

    #region LeftAnalogAxis
    private void UpdateLeftAnalogInput(T player)
    {
        leftAnalogInputReceived.leftAnalogH = Input.GetAxisRaw(Keys.Inputs.LEFTANALOG_H[player.PlayerID]);
        leftAnalogInputReceived.leftAnalogV = Input.GetAxisRaw(Keys.Inputs.LEFTANALOG_V[player.PlayerID]);
        leftAnalogListener.UpdateLeftAnalogInput(leftAnalogInputReceived, player);
    } 
    #endregion

    private void UpdateActionButtonsAxis(T player)
    {
        UpdateAButton(player);
        UpdateBButton(player);
        UpdateXButton(player);
        UpdateYButton(player);
    }

    #region ActionButtonAxis
    private void UpdateAButton(T player)
    {
        A_Button = Input.GetAxisRaw(Keys.Inputs.A_BUTTON[player.PlayerID]);
        if (A_Button > NO_ACTION && !A_ButtonIsDown)
        {
            A_ButtonIsDown = true;
            actionButtonsListener.A_ButtonInputReceived(player);
        }

        if (A_Button.Equals(NO_ACTION)) A_ButtonIsDown = false;
    }

    private void UpdateBButton(T player)
    {
        B_Button = Input.GetAxisRaw(Keys.Inputs.B_BUTTON[player.PlayerID]);
        if (B_Button > NO_ACTION && !B_ButtonIsDown)
        {
            B_ButtonIsDown = true;
            actionButtonsListener.B_ButtonInputReceived(player);
        }

        if (B_Button.Equals(NO_ACTION)) B_ButtonIsDown = false;
    }

    private void UpdateXButton(T player)
    {
        X_Button = Input.GetAxisRaw(Keys.Inputs.X_BUTTON[player.PlayerID]);
        if (X_Button > NO_ACTION && !X_ButtonIsDown)
        {
            X_ButtonIsDown = true;
            actionButtonsListener.X_ButtonInputReceived(player);
        }

        if (X_Button.Equals(NO_ACTION)) X_ButtonIsDown = false;
    }

    private void UpdateYButton(T player)
    {
        Y_Button = Input.GetAxisRaw(Keys.Inputs.Y_BUTTON[player.PlayerID]);
        if (Y_Button > NO_ACTION && !Y_ButtonIsDown)
        {
            Y_ButtonIsDown = true;
            actionButtonsListener.Y_ButtonInputReceived(player);
        }

        if (Y_Button.Equals(NO_ACTION)) Y_ButtonIsDown = false;
    }
    #endregion

    private void UpdateBumperButtonsAxis(T player)
    {
        UpdateRBButton(player);
        UpdateLBButton(player);
    }

    #region BumpersAxis

    private void UpdateRBButton(T player)
    {
        RB_Button = Input.GetAxisRaw(Keys.Inputs.RB_BUTTON[player.PlayerID]);
        if (RB_Button > NO_ACTION && !RB_ButtonIsDown)
        {
            RB_ButtonIsDown = true;
            bumpersListener.RB_ButtonInputReceived(player);
        }

        if (RB_Button.Equals(NO_ACTION)) RB_ButtonIsDown = false;
    }

    private void UpdateLBButton(T player)
    {
        LB_Button = Input.GetAxisRaw(Keys.Inputs.LB_BUTTON[player.PlayerID]);
        if (LB_Button > NO_ACTION && !LB_ButtonIsDown)
        {
            LB_ButtonIsDown = true;
            bumpersListener.LB_ButtonInputReceived(player);
        }

        if (LB_Button.Equals(NO_ACTION)) LB_ButtonIsDown = false;
    }

    #endregion

    private void UpdateTriggersButtonsAxis(T player)
    {
        UpdateTriggerInput(player);
    }

    #region TriggerAxis
    private void UpdateTriggerInput(T player)
    {
        triggerInputReceived.LT = Input.GetAxisRaw(Keys.Inputs.LT_BUTTON[player.PlayerID]);
        triggerInputReceived.RT = Input.GetAxisRaw(Keys.Inputs.RT_BUTTON[player.PlayerID]);
        triggersListener.UpdateTriggerInput(triggerInputReceived, player);
    }
    #endregion

    #region IInputController implementation
    #region Register
    public void RegisterActionButtons(IActionButtons action)
    {
        actionButtonsListener = action;
    }

    public void RegisterBumperButtons(IBumpers bumpers)
    {
        bumpersListener = bumpers;
    }

    public void RegisterTriggerButtons(ITriggers triggers)
    {
        triggersListener = triggers;
    }

    public void RegisterLeftAnalog(ILeftAnalog leftAnalog)
    {
        leftAnalogListener = leftAnalog;
    }

    public void RegisterRightAnalog(IRightAnalog rightAnalog)
    {
        rightAnalogListener = rightAnalog;
    }
    #endregion

    #region Unregister

    public void UnregisterActionButtons()
    {
        A_Button = NO_ACTION;
        A_ButtonIsDown = false;
        B_Button = NO_ACTION;
        B_ButtonIsDown = false;
        X_Button = NO_ACTION;
        X_ButtonIsDown = false;
        Y_Button = NO_ACTION;
        Y_ButtonIsDown = false;
        actionButtonsListener = null;
    }

    public void UnregisterBumperButtons()
    {
        RB_Button = NO_ACTION;
        RB_ButtonIsDown = false;
        LB_Button = NO_ACTION;
        LB_ButtonIsDown = false;
        bumpersListener = null;
    }

    public void UnregisterTriggerButtons()
    {
        triggerInputReceived.LT = NO_ACTION;
        triggerInputReceived.RT = NO_ACTION;
        triggersListener.UpdateTriggerInput(triggerInputReceived, player);
        triggersListener = null;
    }

    public void UnregisterLeftAnalog()
    {
        leftAnalogInputReceived.leftAnalogH = NO_ACTION;
        leftAnalogInputReceived.leftAnalogV = NO_ACTION;
        leftAnalogListener.UpdateLeftAnalogInput(leftAnalogInputReceived, player);
        leftAnalogListener = null;
    }

    public void UnregisterRightAnalog()
    {
        rightAnalogInputReceived.rightAnalogH = NO_ACTION;
        rightAnalogInputReceived.rightAnalogV = NO_ACTION;
        rightAnalogListener.UpdateRightAnalogInput(rightAnalogInputReceived, player);
        rightAnalogListener = null;
    }
    #endregion 
    #endregion

}

