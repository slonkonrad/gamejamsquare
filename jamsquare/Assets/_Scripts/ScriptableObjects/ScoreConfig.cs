using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScoreConfig")]
public class ScoreConfig : ScriptableObject
{
    public int NpcKilledScore;
    public int NpcDeliveredScore;
    public int LapCompletedScore;
    public float LowerLapTimeBound;
    public float UpperLapTimeBound;
}
