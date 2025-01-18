using System;
using UnityEngine;

[Serializable]
public class AttackConfig
{
    [field: SerializeField, Range(1, 5)] public float Damage { get; private set; }
    [field: SerializeField, Range(1, 5)] public float AttackSpeed { get; private set; }
    [field: SerializeField, Range(0.25f, 1)] public float Distance { get; private set; }
}
