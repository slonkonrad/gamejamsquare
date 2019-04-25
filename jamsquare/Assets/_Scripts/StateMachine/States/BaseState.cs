public abstract class BaseState
{
    protected GameController gameController;

    public virtual void InitState(GameController gameController)
    {
        this.gameController = gameController;
    }

    public virtual void UpdateState() { }
    public virtual void DeinitState() { }
}
