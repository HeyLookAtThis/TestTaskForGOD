using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class Character : MonoBehaviour
{
    [SerializeField] private CharacterConfig _config;

    private PlayerInput _input;
    private CharacterController _controller;
    private CharacterStateMachine _stateMachine;

    public PlayerInput Input => _input;
    public CharacterConfig Config => _config;
    public CharacterController Controller => _controller;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();

        _input = new PlayerInput();
        _stateMachine = new CharacterStateMachine(this);
    }

    private void OnEnable() => _input.Enable();
    private void OnDisable() => _input.Disable();

    private void Update()
    {
        _stateMachine.HandleInput();
        _stateMachine.Update();
    }
}
