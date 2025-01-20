using UnityEngine;

public abstract class Target : MonoBehaviour
{
    private Health _health;

    public Health Health => _health;
    public Transform Transform { get; protected set; }

    protected void CreateHealth(HealthConfig healthConfig) => _health = new Health(healthConfig);
}
