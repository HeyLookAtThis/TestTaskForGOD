public class CharacterStateMachine : StateMachine
{
    public CharacterStateMachine(Character character)
    {
        StateMachineData data = new StateMachineData();

        AddState(new CharacterIdilingState(this, data, character));
        AddState(new CharacterRunningState(this, data, character, character.Config.RunningStateConfig));

        SwitchState<CharacterIdilingState>();
    }

    public void HandleInput() => CurrentState.HandleInput();
}
