public interface IBumpers
{
    void LB_ButtonInputReceived<T>(T player) where T : BaseInput;
    void RB_ButtonInputReceived<T>(T player) where T : BaseInput;
}
