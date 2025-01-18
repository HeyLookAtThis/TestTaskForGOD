using UnityEngine;

public class MutantsBehaivorSwitcher
{
    private MutantConfig _config;
    private MutantSearcher _searcher;
    private Mutant _mutant;

    public MutantsBehaivorSwitcher(MutantConfig config, Mutant mutant)
    {
        _config = config;
        _searcher = new MutantSearcher(_config.SearchConfig, mutant);
    }

    public void Update()
    {
        ITarget target = _searcher.TryGetTarget();

        if (target == null)
        {
            _mutant.SetBehaivor(new IdilingBehaivor());
        }
        else
        {
            if (GetDistanse(target) > _config.AttackConfig.Distance)
                _mutant.SetBehaivor(new MoveToPlayerBehaivor(target, _mutant, _config.MoveToPlayerConfig.Speed));
            else
                _mutant.SetBehaivor(new AttackBehaivor(target, _config.AttackConfig.AttackSpeed, _config.AttackConfig.Damage));
        }
    }

    private float GetDistanse(ITarget target) => Vector2.Distance(target.Transform.position, _mutant.Transform.position);
}
