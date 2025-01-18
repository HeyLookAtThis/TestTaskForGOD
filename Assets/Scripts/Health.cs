using UnityEngine.Events;

public class Health
{
    private float _currentValue;
    private float _maxValue;

    private UnityAction _wasOver;

    public Health(float maxValue)
    {
        _maxValue = maxValue;
        _currentValue = _maxValue;
    }

    public event UnityAction WasOver
    {
        add => _wasOver += value;
        remove => _wasOver -= value;
    }

    public void TakeDamage(float damage)
    {
        if(_currentValue > damage)
            _currentValue -= damage;
        else
            _wasOver?.Invoke();
    }
}
