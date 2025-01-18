using UnityEngine;

[CreateAssetMenu(fileName = "MutantConfig", menuName ="Configs/MutantConfig")]
public class MutantConfig : ScriptableObject
{
    [SerializeField] private SearchConfig _searchConfig;
    [SerializeField] private MoveToPlayerConfig _moveToPlayerConfig;
    [SerializeField] private AttackConfig _attackConfig;
    [SerializeField] private HealthConfig _healthConfig;

    public SearchConfig SearchConfig => _searchConfig;
    public MoveToPlayerConfig MoveToPlayerConfig => _moveToPlayerConfig;
    public AttackConfig AttackConfig => _attackConfig;
    public HealthConfig HealthConfig => _healthConfig;
}
