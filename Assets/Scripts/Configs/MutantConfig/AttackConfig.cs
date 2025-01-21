using System;
using UnityEngine;

[Serializable]
public class AttackConfig
{
    [field: SerializeField, Range(0.1f, 2)] public float Damage { get; private set; }
    [field: SerializeField, Range(0.5f, 2)] public float AttackTime { get; private set; }
    [field: SerializeField, Range(0.25f, 1)] public float Distance { get; private set; }
}
