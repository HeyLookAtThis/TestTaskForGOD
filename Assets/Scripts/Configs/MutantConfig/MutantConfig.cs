using System;
using UnityEngine;

[Serializable]
public class MutantConfig
{
    [SerializeField] private Mutant _prefab;
    [SerializeField] private SearchConfig _searchConfig;
    [SerializeField] private MoveToPlayerConfig _moveToPlayerConfig;
    [SerializeField] private AttackConfig _attackConfig;
    [SerializeField] private HealthConfig _healthConfig;

    public Mutant Prefab => _prefab;
    public SearchConfig SearchConfig => _searchConfig;
    public MoveToPlayerConfig MoveToPlayerConfig => _moveToPlayerConfig;
    public AttackConfig AttackConfig => _attackConfig;
    public HealthConfig HealthConfig => _healthConfig;
}
