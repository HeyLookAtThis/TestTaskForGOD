using UnityEngine;

public class Mutant : MonoBehaviour, ITarget
{
    [SerializeField] private MutantConfig _config;

    private IBehaivor _currentBehaivor;
    private MutantsBehaivorSwitcher _switcher;
    private Health _health;

    public Health Health => _health;
    public Transform Transform => transform;

    private void Awake()
    {
        _health = new Health(_config.HealthConfig.MaxHealth);
    }

    private void Update()
    {
        _currentBehaivor.Update();
    }

    public void SetBehaivor(IBehaivor behaivor)
    {
        _currentBehaivor?.StopBehaivor();
        _currentBehaivor = behaivor;
        _currentBehaivor.StartBehaivor();
    }
}
