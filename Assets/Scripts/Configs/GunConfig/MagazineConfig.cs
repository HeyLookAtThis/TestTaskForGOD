using System;
using UnityEngine;

[Serializable]
public class MagazineConfig
{
    [field: SerializeField, Range(1,30)] public int Capacity { get; private set; }
}
