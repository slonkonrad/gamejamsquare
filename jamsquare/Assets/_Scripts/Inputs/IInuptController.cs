public interface IInuptController
{
    void RegisterActionButtons(IActionButtons action);
    void RegisterBumperButtons(IBumpers bumpers);
    void RegisterTriggerButtons(ITriggers triggers);
    void RegisterLeftAnalog(ILeftAnalog leftAnalog);
    void RegisterRightAnalog(IRightAnalog leftAnalog);

    void UnregisterActionButtons();
    void UnregisterBumperButtons();
    void UnregisterTriggerButtons();
    void UnregisterLeftAnalog();
    void UnregisterRightAnalog();

}
