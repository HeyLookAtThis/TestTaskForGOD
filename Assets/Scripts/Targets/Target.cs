using UnityEngine;

[RequireComponent (typeof(CapsuleCollider2D))]
public abstract class Target : MonoBehaviour
{
    public abstract Health Health { get; }
    public abstract Transform Transform { get; }
}
