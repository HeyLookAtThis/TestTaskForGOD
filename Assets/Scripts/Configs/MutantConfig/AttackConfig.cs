using System;
using UnityEngine;

[Serializable]
public class AttackConfig
{
    [field: SerializeField, Range(1, 5)] public float Damage { get; private set; }
    [field: SerializeField, Range(1, 5)] public float Speed { get; private set; }
    [field: SerializeField, Range(1, 5)] public float Distance { get; private set; }
}
