using UnityEngine;

public class MoveToPlayerBehaivor : IBehaivor
{
    private bool _isMoving;
    private float _speed;

    private ITarget _player;
    private ITarget _mutant;

    public MoveToPlayerBehaivor(ITarget player, ITarget mutant, float speed)
    {
        _player = player;
        _mutant = mutant;
        _speed = speed;
    }

    public void StartBehaivor() => _isMoving = true;
    public void StopBehaivor() => _isMoving = false;

    public void Update()
    {
        if (_isMoving == false)
            return;

        MoveToPlayer();
        LookAtPlayer();
    }

    private void MoveToPlayer() => _mutant.Transform.Translate(_player.Transform.position * _speed * Time.deltaTime);
    private void LookAtPlayer() => _mutant.Transform.LookAt(_player.Transform.position);
}
