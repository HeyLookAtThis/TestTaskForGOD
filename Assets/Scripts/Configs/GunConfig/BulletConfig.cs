using System;
using UnityEngine;

[Serializable]
public class BulletConfig
{
    [field: SerializeField, Range(0.25f, 2)] public float Damage { get; private set; }
    [field: SerializeField, Range(5, 10)] public float Speed { get; private set; }
}
