using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Configs", menuName = "Configs/MutantFactory")]
public class MutantFactory : ScriptableObject
{
    [SerializeField] private MutantConfig _zombie, _bigDog;

    public Mutant Get(MutantType type)
    {
        MutantConfig config = GetConfig(type);
        Mutant instance = Instantiate(config.Prefab);
        instance.Initialize(config);
        return instance;
    }

    private MutantConfig GetConfig(MutantType enemyType)
    {
        switch (enemyType)
        {
            case MutantType.Zombie:
                return _zombie;

            case MutantType.BigDog:
                return _bigDog;

            default:
                throw new ArgumentException(nameof(enemyType));
        }
    }
}
