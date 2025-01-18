using UnityEngine;

public interface ITarget
{
    Health Health { get; }
    Transform Transform { get; }
}
