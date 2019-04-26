using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameView : BaseView
{
    public IGameView listener;

    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI killedPeopleText;
    [SerializeField]
    private TextMeshProUGUI deliveredPeopleText;
    [SerializeField]
    private TextMeshProUGUI bestLapTimeText;
    [SerializeField]
    private TextMeshProUGUI lapCountText;


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

    public void UpdateScore(Score score)
    {
        scoreText.text = score.ScoreValue.ToString();
        killedPeopleText.text = score.PeopleKilled.ToString();
        deliveredPeopleText.text = score.PeopleDelivered.ToString();
        bestLapTimeText.text = (float.MaxValue - score.MinLapTime) < float.Epsilon ? "---" : score.MinLapTime.ToString();
        lapCountText.text = score.LapCount.ToString();
    }
}
