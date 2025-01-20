using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Target _target;
    [SerializeField] private Slider _slider;

    private Health _health;

    private Coroutine _valueChanger;

    private void Awake()
    {
        _health = _target.Health;
    }

    private void OnEnable()
    {
        SetMaxValue();
        _health.Changed += OnChangeValue;
    }

    private void OnDisable()
    {
        _health.Changed -= OnChangeValue;
    }

    private void SetMaxValue()
    {
        _slider.maxValue = _health.MaxValue;
        _slider.value = _slider.maxValue;
    }

    private void OnChangeValue(float value)
    {
        if (_valueChanger != null)
            StopCoroutine(_valueChanger);

        _valueChanger = StartCoroutine(ValueChanger(value));
    }

    private IEnumerator ValueChanger(float value)
    {
        var WaitTime = new WaitForEndOfFrame();
        while(_slider.value != value)
        {
            _slider.value += _speed * Time.deltaTime * GetMultiplier(value, _slider.value);
            yield return WaitTime;
        }

        if (_slider.value == value)
            yield break;
    }

    private float GetMultiplier(float value, float sliderValue)
    {
        float multiplier = 1;

        if (sliderValue > value)
            return -multiplier;

        return multiplier;
    }
}
