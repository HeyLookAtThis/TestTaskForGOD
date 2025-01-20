using UnityEngine;

public class TargetForPlayer : Target
{
    [SerializeField] private Mutant _mutant;

    private void Awake()
    {
        Transform = _mutant.transform;
        CreateHealth(_mutant.Config.HealthConfig);
    }
}
