using UnityEngine;
using UnityEngine.Events;

public class Searcher
{
    private SearchConfig _config;

    private LayerMask _targetLayerMask;
    private Target _target;
    private float _radius;

    private UnityAction _foundTarget;

    public Searcher(SearchConfig config)
    {
        _config = config;
        _radius = _config.Radius;
        _targetLayerMask = _config.TargetLayer;
    }

    public Target Target => _target;

    public event UnityAction FoundTarget
    {
        add => _foundTarget += value;
        remove => _foundTarget -= value;
    }

    public void Update(Vector2 position)
    {
        if (_target == null)
            TryInitializeTarget(position);

        if (_target != null)
            if (GetDistanseToTarget(position) > _radius || _target.gameObject.activeSelf == false)
                _target = null;
    }

    private void TryInitializeTarget(Vector2 position)
    {
        var collider = Physics2D.OverlapCircle(position, _radius, _targetLayerMask);

        if (collider != null)
        {
            if (collider.TryGetComponent<Target>(out Target target))
            {
                _foundTarget?.Invoke();
                _target = target;
            }
        }
    }

    private float GetDistanseToTarget(Vector2 position) => Vector2.Distance(_target.Transform.position, position);
}
