public interface IScoreListener
{
    void NpcKilled(int playerId);
    void FinishedLap(int playerId, int numberOfNpcOnBoard);
    void UpdateScore(Score score);
}