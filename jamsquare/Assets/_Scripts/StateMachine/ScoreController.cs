using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{ 
    public IScoreListener ScoreListener { get; set; }
    private Dictionary<int, Score> playerScores;

    [SerializeField]
    private ScoreConfig scoreConfig;

    private void Awake()
    {
        playerScores = new Dictionary<int, Score>()
        {
            {Keys.Players.PLAYER_ONE, new Score(scoreConfig) },
            {Keys.Players.PLAYER_TWO, new Score(scoreConfig) }
        };
    }


    public void NpcKilled(int playerId)
    {
        playerScores[playerId].NpcKilled();
        ScoreListener.UpdateScore(playerScores[playerId]);
    }

    public void ArrivedAtStation(int playerId, int numberOfNpcOnBoard)
    {
        playerScores[playerId].FinishedLap(numberOfNpcOnBoard);
        ScoreListener.UpdateScore(playerScores[playerId]);
    }
    public void StartLap(int playerId)
    {
        playerScores[playerId].StartLap();
    }
}