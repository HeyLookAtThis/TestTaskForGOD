using System;
using UnityEngine;

public class StateMachineData
{
    public Vector2 InputDirection;
    private float _speed;

    public float Speed
    {
        get
        {
            return _speed;
        }
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _speed = value;
        }
    }
}
