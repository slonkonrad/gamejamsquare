public interface IScoreListener
{
    void NpcKilled(string playerName);
    void FinishedLap(string playerName, int numberOfNpcOnBoard);
    void UpdateScore(Score score);
}