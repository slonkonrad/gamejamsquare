public interface ILeftAnalog
{
    void UpdateLeftAnalogInput<T>(InputController<T>.LeftAnalogInput leftAnalogInputReceived, T player) where T : BaseInput;
}
