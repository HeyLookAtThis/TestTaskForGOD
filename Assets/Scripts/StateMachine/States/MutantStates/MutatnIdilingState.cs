public class MutatnIdilingState : IState
{
    private readonly Searcher _searcher;
    private readonly IStateSwitcher _switcher;

    public MutatnIdilingState(Searcher searcher, IStateSwitcher stateSwitcher)
    {
        _searcher = searcher;
        _switcher = stateSwitcher;
    }

    public void Enter() => _searcher.FoundTarget += OnSwitchToMoveState;

    public void Exit() => _searcher.FoundTarget -= OnSwitchToMoveState;

    public void HandleInput()
    {
    }

    public void Update()
    {
    }

    private void OnSwitchToMoveState() => _switcher.SwitchState<MoveToPlayerState>();
}
