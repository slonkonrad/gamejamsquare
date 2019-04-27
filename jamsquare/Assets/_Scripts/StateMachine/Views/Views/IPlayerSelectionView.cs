using UnityEngine;
using UnityEditor;

public interface IPlayerSelectionView
{
    void OnSingleplayerButtonFocused();
    void OnMultiplayerButtonFocused();
    void SetGameState();
}