using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{ 
    public IScoreListener ScoreListener { get; set; }
    private Dictionary<string, Score> playerScores;

    [SerializeField]
    private ScoreConfig scoreConfig;

    private void Awake()
    {
        playerScores = new Dictionary<string, Score>()
        {
            {"Player 1", new Score(scoreConfig) }
        };
    }


    public void NpcKilled(string playerName)
    {
        playerScores[playerName].NpcKilled();
        ScoreListener.UpdateScore(playerScores[playerName]);
    }

    public void ArrivedAtStation(string playerName, int numberOfNpcOnBoard)
    {
        playerScores[playerName].FinishedLap(numberOfNpcOnBoard);
        ScoreListener.UpdateScore(playerScores[playerName]);
    }
    public void StartLap(string playerName)
    {
        playerScores[playerName].StartLap();
    }
}