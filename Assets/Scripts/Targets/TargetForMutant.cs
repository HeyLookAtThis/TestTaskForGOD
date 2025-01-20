using UnityEngine;

public class TargetForMutant : Target
{
    [SerializeField] private Character _character;

    private void Awake()
    {
        Transform = _character.transform;
        CreateHealth(_character.Config.HealthConfig);
    }
}
