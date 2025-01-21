public class CharacterIdilingState : MovementState
{
    public CharacterIdilingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Update()
    {
        base.Update();

        if(IsInputDirectionZero)
            return;

        StateSwitcher.SwitchState<CharacterRunningState>();
    }
}
