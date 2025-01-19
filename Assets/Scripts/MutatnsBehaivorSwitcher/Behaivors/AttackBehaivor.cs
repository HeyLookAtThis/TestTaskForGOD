using UnityEngine;

public class AttackBehaivor : IBehaivor
{
    private readonly ITarget _player;
    private readonly float _attackTime;

    private AttackConfig _config;

    private float _lastAttackTime;
    private bool _canAttack;

    public AttackBehaivor(ITarget player, AttackConfig config)
    {
        _player = player;
        _config = config;
    }

    public void StartBehaivor() => _canAttack = true;
    public void StopBehaivor() => _canAttack = false;

    public void Update()
    {
        if (_canAttack == false)
            return;

        _lastAttackTime += Time.deltaTime;

        if(_lastAttackTime >= _attackTime)
        {
            _lastAttackTime = 0;
            Attack();
        }
    }

    private void Attack() => _player.Health.TakeDamage(_config.Damage);
}
