using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIController : MonoBehaviour
{
    [SerializeField] private MenuView menuView;

    public BaseView CurrentView { get; set; }
    public MenuView MenuView => menuView;

    [SerializeField] private PlayerSelectionView playerSelectionView;
    public PlayerSelectionView PlayerSelectionView => playerSelectionView;

    public void SetActiveView(BaseView view)
    {
        if (CurrentView != null) CurrentView.HideView();

        CurrentView = view;

        if (CurrentView != null) CurrentView.ShowView();
    }



}
