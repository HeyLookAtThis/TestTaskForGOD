using System;
using UnityEngine;

[Serializable]
public class MoveToPlayerConfig
{
    [field: SerializeField, Range(1, 5)] public float Speed { get; private set; }
}
