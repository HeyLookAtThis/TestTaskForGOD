using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class FireMediator : MonoBehaviour
{
    [SerializeField] private Button _fireButton;

    private Character _character;

    private void OnEnable() => _fireButton.onClick.AddListener(OnFire);

    private void OnDisable() => _fireButton.onClick.RemoveListener(OnFire);

    [Inject]
    private void Construct(Character character) => _character = character;
    private void OnFire() => _character.Automat.Fire(_character.Searcher.Target);
}
