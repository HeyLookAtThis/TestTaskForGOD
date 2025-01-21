using UnityEngine;

public class TargetForMutant : Target
{
    [SerializeField] private Character _character;

    public override Health Health => _character.Health;
    public override Transform Transform => _character.transform;
}
