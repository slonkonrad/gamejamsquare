public interface IRightAnalog
{
    void UpdateRightAnalogInput<T>(InputController<T>.RightAnalogInput rightAnalogInputReceived, T player) where T : BaseInput;
}
