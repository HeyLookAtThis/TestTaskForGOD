using UnityEngine;

public class MoveToPlayerBehaivor : IBehaivor
{
    private readonly Target _player;

    private MoveToPlayerConfig _config;

    private bool _isMoving;
    private float _previousXPosition;
    private Target _mutant;

    public MoveToPlayerBehaivor(Target player, Target mutant, MoveToPlayerConfig config)
    {
        _player = player;
        _mutant = mutant;
        _config = config;
    }

    private Quaternion TurnRight => Quaternion.identity;
    private Quaternion TurnLeft => Quaternion.Euler(0, 180, 0);

    public void StartBehaivor() => _isMoving = true;
    public void StopBehaivor() => _isMoving = false;

    public void Update()
    {
        if (_isMoving == false)
            return;

        MoveToPlayer();
        Rotate();
    }

    private void MoveToPlayer() => _mutant.Transform.position = Vector2.MoveTowards(_mutant.Transform.position, _player.Transform.position, _config.Speed * Time.deltaTime);
    private void Rotate()
    {
        float xPosition = _mutant.Transform.position.x;

        if (xPosition < _previousXPosition)
            _mutant.Transform.rotation = TurnLeft;

        if (xPosition > _previousXPosition)
            _mutant.Transform.rotation = TurnRight;

        _previousXPosition = xPosition;
    }
}
