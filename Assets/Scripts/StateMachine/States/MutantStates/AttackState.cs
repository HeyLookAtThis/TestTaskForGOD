using UnityEngine;

public class AttackState : IState
{
    private readonly float _attackTime;
    private readonly IStateSwitcher _switcher;

    private AttackConfig _config;
    private Mutant _mutant;

    private float _lastAttackTime;
    private bool _canAttack;

    public AttackState(Mutant mutant, IStateSwitcher stateSwitcher)
    {
        _config = mutant.Config.AttackConfig;
        _attackTime = _config.AttackTime;

        _switcher = stateSwitcher;
        _mutant = mutant;
    }

    private Target Player => _mutant.Searcher.Target;

    public void Enter()
    {
        _canAttack = true;
        _lastAttackTime = _attackTime;
    }
    public void Exit() => _canAttack = false;
    public void HandleInput()
    {
    }

    public void Update()
    {
        if (_canAttack == false)
            return;

        if(_lastAttackTime >= _attackTime)
        {
            _lastAttackTime = 0;
            Attack();
        }

        _lastAttackTime += Time.deltaTime;

        TrySwitchToMoveState();
        TrySwitchToIdilingState();
    }

    private void Attack() => Player.Health.TakeDamage(_config.Damage);
    private float GetDistanseToTarget() => Vector2.Distance(Player.Transform.position, _mutant.Transform.position);

    private void TrySwitchToMoveState()
    {
        if (GetDistanseToTarget() > _config.Distance)
            _switcher.SwitchState<MoveToPlayerState>();
    }

    private void TrySwitchToIdilingState()
    {
        if (Player == null || Player.Health.Value == 0)
            _switcher.SwitchState<MutatnIdilingState>();
    }
}
