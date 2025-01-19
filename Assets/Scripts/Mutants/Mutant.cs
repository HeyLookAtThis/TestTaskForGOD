using UnityEngine;

public class Mutant : MonoBehaviour, ITarget
{
    [SerializeField] private MutantConfig _config;
    [SerializeField] private MutantSearcher _searcher;

    private MutantsBehaivorSwitcher _switcher;

    private IBehaivor _currentBehaivor;
    private Health _health;

    public Health Health => _health;
    public Transform Transform => transform;
    public MutantConfig Config => _config;

    private void Awake()
    {
        _health = new Health(_config.HealthConfig.MaxHealth);
        _switcher = new MutantsBehaivorSwitcher(this, _searcher);
    }

    private void OnEnable()
    {
        _switcher.AddActionsCallback();
    }

    private void OnDisable()
    {
        _switcher.RemoveActionsCallback();
    }

    private void Update()
    {
        _switcher.Update();
        _currentBehaivor.Update();
    }

    public void SetBehaivor(IBehaivor behaivor)
    {
        Debug.Log(behaivor);


        _currentBehaivor?.StopBehaivor();
        _currentBehaivor = behaivor;
        _currentBehaivor.StartBehaivor();
    }
}
