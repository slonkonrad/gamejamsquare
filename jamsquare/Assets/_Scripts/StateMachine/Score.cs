using UnityEngine;

public class Score
{
    public int ScoreValue { get; private set; }
    public int PeopleKilled { get; private set; }
    public int PeopleDelivered { get; private set; }
    public float MinLapTime { get; private set; }
    public float MaxLapTime { get; private set; }
    public float AverageLapTime { get; private set; }
    public int LapCount { get; private set; }

    private ScoreConfig scoreConfig;
    private float startLapTime;
    private float totalTime;

    public Score(ScoreConfig scoreConfig)
    {
        this.scoreConfig = scoreConfig;
        
        ScoreValue = 0;
        PeopleKilled = 0;
        PeopleDelivered = 0;
        MinLapTime = float.MaxValue;
        MaxLapTime = float.MinValue;
        AverageLapTime = 0;
        totalTime = 0;
        LapCount = 0;
    }

    public void NpcKilled()
    {
        PeopleKilled++;
        ScoreValue += scoreConfig.NpcKilledScore;
    }

    public void FinishedLap(int numberOfNpcOnBoard)
    {
        PeopleDelivered += numberOfNpcOnBoard;
        ScoreValue += numberOfNpcOnBoard * scoreConfig.NpcDeliveredScore;

        float lapTime = (Time.time - startLapTime);

        if (lapTime <= scoreConfig.LowerLapTimeBound)
        {
            ScoreValue += scoreConfig.LapCompletedScore;
        }
        else if (lapTime >= scoreConfig.UpperLapTimeBound)
        {
            ScoreValue += 0;
        }
        else
        {
            ScoreValue += (int) ((lapTime - scoreConfig.LowerLapTimeBound) /
                                 (scoreConfig.UpperLapTimeBound - scoreConfig.LowerLapTimeBound) *
                                 scoreConfig.LapCompletedScore);
        }

        MinLapTime = Mathf.Min(MinLapTime, lapTime);
        MaxLapTime = Mathf.Max(MaxLapTime, lapTime);
        LapCount++;
        totalTime += lapTime;
        AverageLapTime = totalTime / LapCount;

        startLapTime = Time.time;
    }

    public void StartLap()
    {
        startLapTime = Time.time;
    }
}