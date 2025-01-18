using System.Collections.Generic;
using System.Linq;

public class CharacterStateMachine : IStateSwitcher
{
    private IState _currentState;
    private List<IState> _states;

    public CharacterStateMachine(Character character)
    {
        StateMachineData data = new StateMachineData();

        _states = new List<IState>()
        {
            new IdilingState(this, data, character),
            new RunningState(this, data, character, character.Config.RunningStateConfig)
        };

        SwitchState<IdilingState>();
    }

    public void SwitchState<T>() where T : IState
    {
        IState state = _states.FirstOrDefault(state => state is T);

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void HandleInput() => _currentState.HandleInput();
    public void Update() => _currentState.Update();
}
