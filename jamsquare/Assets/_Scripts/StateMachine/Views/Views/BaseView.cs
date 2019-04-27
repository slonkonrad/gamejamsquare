using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseView : MonoBehaviour
{
    public virtual void ShowView()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void HideView()
    {
        this.gameObject.SetActive(false);
    }

    public virtual void ExecuteFocusedButton<T>(T player) where T:BaseInput
    { }

    public virtual void SwitchButtonFocus<T>(InputController<T>.LeftAnalogInput leftAnalogInputReceived) where T : BaseInput
    { }
}
