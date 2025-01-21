using System.Collections.Generic;
using System.Linq;

public abstract class StateMachine : IStateSwitcher
{
    protected IState CurrentState;
    private List<IState> _states;

    public StateMachine() => _states = new List<IState>();

    public void SwitchState<T>() where T : IState
    {
        IState state = _states.FirstOrDefault(state => state is T);

        CurrentState?.Exit();
        CurrentState = state;
        CurrentState.Enter();
    }

    public void Update() => CurrentState.Update();
    protected void AddState(IState state) => _states.Add(state);
}
