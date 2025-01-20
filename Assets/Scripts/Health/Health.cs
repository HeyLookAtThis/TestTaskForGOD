using UnityEngine.Events;

public class Health
{
    private HealthConfig _config;
    private float _currentValue;
    private float _maxValue;
    private float _minValue;

    private UnityAction _wasOver;
    private UnityAction<float> _changed;

    public Health(HealthConfig config)
    {
        _config = config;
        _maxValue = _config.MaxHealth;
        _currentValue = _maxValue;
        _minValue = 0;
    }

    public event UnityAction WasOver
    {
        add => _wasOver += value;
        remove => _wasOver -= value;
    }

    public event UnityAction<float> Changed
    {
        add => _changed += value;
        remove => _changed -= value;
    }

    public float MaxValue => _maxValue;

    public void TakeDamage(float damage)
    {
        if(_currentValue > damage)
        {
            _currentValue -= damage;
            _changed?.Invoke(_currentValue);
        }
        else
        {
            _currentValue = _minValue;
            _changed?.Invoke(_currentValue);
            _wasOver?.Invoke();
        }
    }
}
