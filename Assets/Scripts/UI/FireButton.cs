using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FireButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    public void AddListener(UnityAction action) => _button.onClick.AddListener(action);
    public void RemoveListener(UnityAction action) => _button.onClick.RemoveListener(action);
}
