using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceController : MonoBehaviour
{
    public IScoreListener scoreListener;
    [SerializeField]
    private CheckPoint[] checkpoints;

    private Dictionary<int, int> playersProgressInRace;

    private void Start()
    {
        playersProgressInRace = new Dictionary<int, int>()
        {
            {Keys.Players.PLAYER_ONE, 0 },
            {Keys.Players.PLAYER_TWO, 0 }
        };

        foreach (CheckPoint checkpoint in checkpoints)
        {
            checkpoint.HandleCheckpoint += Checkpoint_HandleCheckpoint;
        }
    }

    private void Checkpoint_HandleCheckpoint(CheckPoint checkpoint, int playerId)
    {
        if (checkpoint.CheckpointNumber == playersProgressInRace[playerId] + 1) playersProgressInRace[playerId] += 1;
        if (playersProgressInRace[playerId] == checkpoints.Length)
        {
            scoreListener.FinishedLap(playerId, 0); // TODO: replace by actual value
            playersProgressInRace[playerId] = 0;
        }
    }

    private void OnDestroy()
    {
        foreach (CheckPoint checkPoint in checkpoints)
        {
            checkPoint.HandleCheckpoint -= Checkpoint_HandleCheckpoint;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
