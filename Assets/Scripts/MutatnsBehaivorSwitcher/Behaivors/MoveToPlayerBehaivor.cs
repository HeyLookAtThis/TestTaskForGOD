using UnityEngine;

public class MoveToPlayerBehaivor : IBehaivor
{
    private readonly ITarget _player;

    private MoveToPlayerConfig _config;

    private bool _isMoving;

    private ITarget _mutant;

    public MoveToPlayerBehaivor(ITarget player, ITarget mutant, MoveToPlayerConfig config)
    {
        _player = player;
        _mutant = mutant;
        _config = config;
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

    private void MoveToPlayer() => _mutant.Transform.Translate(_player.Transform.position * _config.Speed * Time.deltaTime);
    private void LookAtPlayer() => _mutant.Transform.LookAt(_player.Transform.position);
}
