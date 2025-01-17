using UnityEngine;

public abstract class MovementState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly StateMachineData Data;

    private readonly Character _character;

    public MovementState(IStateSwitcher stateSwitcher, StateMachineData data, Character character)
    {
        StateSwitcher = stateSwitcher;
        Data = data;
        _character = character;
    }

    public bool IsInputDirectionZero => Data.InputDirection == Vector2.zero;

    protected CharacterController Controller => _character.Controller;
    protected PlayerInput Input => _character.Input;

    private Quaternion TurnRight => Quaternion.identity;
    private Quaternion TurnLeft => Quaternion.Euler(0, 180, 0);

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void Update()
    {
        Move();
        Rotate();
    }
    public void HandleInput() => Data.InputDirection = ReadInputDirection();

    private Vector2 ReadInputDirection() => Input.Movement.Move.ReadValue<Vector2>();

    private void Move() => Controller.Move(Data.Speed * Time.deltaTime * ReadInputDirection());
    private void Rotate()
    {
        if (Data.InputDirection.x > 0)
            _character.transform.rotation = TurnRight;

        if (Data.InputDirection.x < 0)
            _character.transform.rotation = TurnLeft;
    }
}
