public interface ITriggers
{
    void UpdateTriggerInput<T>(InputController<T>.TriggerInput triggerInputReceived, T player) where T : BaseInput;
}
