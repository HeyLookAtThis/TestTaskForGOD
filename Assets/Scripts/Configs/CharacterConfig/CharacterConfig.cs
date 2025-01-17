using UnityEngine;

[CreateAssetMenu(fileName ="CharacterConfig", menuName ="Config/CharacterConfig")]
public class CharacterConfig :ScriptableObject
{
    [SerializeField] private RunningStateConfig _runningStateConfig;

    public RunningStateConfig RunningStateConfig => _runningStateConfig;
}
