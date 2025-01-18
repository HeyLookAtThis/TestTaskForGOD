using UnityEngine;

[CreateAssetMenu(fileName ="CharacterConfig", menuName ="Configs/CharacterConfig")]
public class CharacterConfig :ScriptableObject
{
    [SerializeField] private RunningStateConfig _runningStateConfig;
    [SerializeField] private SearchConfig _searchingConfig;
    [SerializeField] private HealthConfig _healthConfig;

    public RunningStateConfig RunningStateConfig => _runningStateConfig;
    public SearchConfig SearchingConfig => _searchingConfig;
    public HealthConfig HealthConfig => _healthConfig;
}
