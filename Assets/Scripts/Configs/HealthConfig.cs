using System;
using UnityEngine;

[Serializable]
public class HealthConfig
{
    [field: SerializeField, Range(1, 5)] public float MaxHealth { get; private set; }
}
