﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : BaseView
{
    public IGameView listener;

    public override void ShowView()
    {
        base.ShowView();
    }

    public override void HideView()
    {
        base.HideView();
    }

    public void SetMenuState()
    {
        listener.SetMenuState();
    }
}
