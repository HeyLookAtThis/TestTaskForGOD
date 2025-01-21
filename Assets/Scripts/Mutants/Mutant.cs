using UnityEngine;

public class Mutant : Target
{
    [SerializeField] private HealthBar _healthBar;

    private MutantConfig _config;    
    private Searcher _searcher;
    private Health _health;
    private MutantStateMachine _stateMachine;

    public override Transform Transform => transform;
    public override Health Health => _health;
    public MutantConfig Config => _config;
    public Searcher Searcher => _searcher;

    private void Update()
    {
        _stateMachine.Update();
        _searcher.Update(transform.position);
    }

    public void Initialize(MutantConfig config)
    {
        _config = config;
        _searcher = new Searcher(_config.SearchConfig);
        _health = new Health(_config.HealthConfig);
        _stateMachine = new MutantStateMachine(this);
        _healthBar.Initialize(_health);
    }
}
