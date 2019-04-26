[System.Serializable]
public class BaseInput
{
    public enum PlayerKey {one = 0, two = 1 }
    public PlayerKey playerKey;

    public int PlayerID { get { return (int)playerKey; } }
}
