using System;
using UnityEngine;

[Serializable]
public class SearchConfig
{
    [field: SerializeField, Range(1, 5)] public float Radius { get; private set; }
    [field: SerializeField] public LayerMask TargetLayer {  get; private set; }
}
