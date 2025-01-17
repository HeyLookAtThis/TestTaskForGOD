public class IdilingState : MovementState
{
    public IdilingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Update()
    {
        base.Update();

        if(IsInputDirectionZero)
            return;

        StateSwitcher.SwitchState<RunningState>();
    }
}
