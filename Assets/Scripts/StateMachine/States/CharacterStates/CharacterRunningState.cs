using UnityEngine;

public class CharacterRunningState : MovementState
{
    private RunningStateConfig _config;

    public CharacterRunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character, RunningStateConfig config) : base(stateSwitcher, data, character) => _config = config;

    public override void Enter()
    {
        base.Enter();
        Data.Speed = _config.Speed;
    }

    public override void Update()
    {
        base.Update();



        if (IsInputDirectionZero)
            StateSwitcher.SwitchState<CharacterIdilingState>();
    }
}
