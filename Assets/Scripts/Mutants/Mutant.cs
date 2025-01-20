using UnityEngine;

public class Mutant : MonoBehaviour
{
    [SerializeField] private MutantConfig _config;
    [SerializeField] private MutantSearcher _searcher;
    [SerializeField] private TargetForPlayer _targetForPlayer;

    private MutantsBehaivorSwitcher _switcher;

    private IBehaivor _currentBehaivor;

    public MutantConfig Config => _config;

    private void Awake()
    {
        _switcher = new MutantsBehaivorSwitcher(this, _searcher, _targetForPlayer);
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
        _switcher.TryReachAttackBehaivor();
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
