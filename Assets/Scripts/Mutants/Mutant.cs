using UnityEngine;

public class Mutant : MonoBehaviour
{
    [SerializeField] private MutantConfig _config;

    private IBehaivor _currentBehaivor;

    private void Update() => _currentBehaivor.Update();

    public void SetBehaivor(IBehaivor behaivor)
    {
        _currentBehaivor?.StopBehaivor();
        _currentBehaivor = behaivor;
        _currentBehaivor.StartBehaivor();
    }
}
