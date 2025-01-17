using System;
using UnityEngine;

[Serializable]
public class RunningStateConfig
{
    [field: SerializeField, Range(1, 10)] public float Speed { get; private set; }
}
