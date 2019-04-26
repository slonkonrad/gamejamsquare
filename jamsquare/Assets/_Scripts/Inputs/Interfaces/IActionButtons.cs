public interface IActionButtons
{
    void A_ButtonInputReceived<T>(T player) where T : BaseInput;
    void B_ButtonInputReceived<T>(T player) where T : BaseInput;
    void X_ButtonInputReceived<T>(T player) where T : BaseInput;
    void Y_ButtonInputReceived<T>(T player) where T : BaseInput;
}
