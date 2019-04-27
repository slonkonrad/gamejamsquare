using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectionView : BaseView
{
    public IMenuView Listener;

    public void SetNumberOfPlayers(int numberOfPlayers)
    {
        GameSettings.NumberOfPlayers = numberOfPlayers;
        SetGameState();
    }

    private void SetGameState()
    {
        Listener.SetGameState();
    }
}
