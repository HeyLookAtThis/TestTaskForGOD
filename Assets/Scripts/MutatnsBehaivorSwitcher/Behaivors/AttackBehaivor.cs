using UnityEngine;

public class AttackBehaivor : IBehaivor
{
    private bool _canAttack;

    private ITarget _player;

    private float _lastAttackTime;
    private float _attackTime;

    private float _damage;

    public AttackBehaivor(ITarget player,  float attackSpeed, float damage)
    {
        _player = player;
        _attackTime = attackSpeed;
        _damage = damage;
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

    private void Attack() => _player.Health.TakeDamage(_damage);
}
