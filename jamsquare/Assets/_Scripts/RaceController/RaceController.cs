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

    private void Checkpoint_HandleCheckpoint(CheckPoint checkpoint, PlayerCar player)
    {
        if (checkpoint.CheckpointNumber == playersProgressInRace[player.PlayerId] + 1) playersProgressInRace[player.PlayerId] += 1;
        if (playersProgressInRace[player.PlayerId] == checkpoints.Length)
        {
            int peopleOnBoard = player.gameObject.GetComponent<HumanCollector>().HumanCount;
            scoreListener.FinishedLap(player.PlayerId, peopleOnBoard); 
            playersProgressInRace[player.PlayerId] = 0;
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
