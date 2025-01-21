using UnityEngine;

public class MoveToPlayerState : IState
{
    private readonly Searcher _searcher;
    private readonly IStateSwitcher _stateSwitcher;

    private MoveToPlayerConfig _config;

    private bool _isMoving;
    private float _previousXPosition;
    private Target _mutant;

    public MoveToPlayerState(Mutant mutant, IStateSwitcher stateSwitcher)
    {
        _searcher = mutant.Searcher;
        _mutant = mutant;
        _config = mutant.Config.MoveToPlayerConfig;
        _stateSwitcher = stateSwitcher;
    }

    private Target Player => _searcher.Target;
    private Quaternion TurnRight => Quaternion.identity;
    private Quaternion TurnLeft => Quaternion.Euler(0, 180, 0);

    public void Enter() => _isMoving = true;
    public void Exit() => _isMoving = false;

    public void HandleInput()
    {
    }

    public void Update()
    {
        if (_isMoving == false)
            return;

        if(_searcher.Target != null)
        {
            MoveToPlayer();
            Rotate();

            if (_config.TargetDistance > GetDistanseToTarget())
                _stateSwitcher.SwitchState<AttackState>();
        }
        else
        {
            _stateSwitcher.SwitchState<MutatnIdilingState>();
        }
    }

    private void MoveToPlayer() => _mutant.Transform.position = Vector2.MoveTowards(_mutant.Transform.position, Player.Transform.position, _config.Speed * Time.deltaTime);
    private void Rotate()
    {
        float xPosition = _mutant.Transform.position.x;

        if (xPosition < _previousXPosition)
            _mutant.Transform.rotation = TurnLeft;

        if (xPosition > _previousXPosition)
            _mutant.Transform.rotation = TurnRight;

        _previousXPosition = xPosition;
    }
    private float GetDistanseToTarget() => Vector2.Distance(_searcher.Target.Transform.position, _mutant.Transform.position);
}
