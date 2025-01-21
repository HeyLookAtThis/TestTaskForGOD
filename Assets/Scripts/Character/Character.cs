using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class Character : MonoBehaviour
{
    [SerializeField] private CharacterConfig _config;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private Automat _automat;

    private Health _health;
    private Target _target;
    private Searcher _searcher;
    private PlayerInput _input;
    private CharacterController _controller;
    private CharacterStateMachine _stateMachine;

    public CharacterController Controller => _controller;
    public CharacterConfig Config => _config;
    public Searcher Searcher => _searcher;
    public PlayerInput Input => _input;
    public Automat Automat => _automat;
    public Health Health => _health;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();

        _input = new PlayerInput();
        _stateMachine = new CharacterStateMachine(this);
        _health = new Health(_config.HealthConfig);
        _searcher = new Searcher(_config.SearchingConfig);
    }

    private void OnEnable() => _input.Enable();
    private void OnDisable() => _input.Disable();

    private void Update()
    {
        _stateMachine.HandleInput();
        _stateMachine.Update();
        _searcher.Update(transform.position);
        Debug.Log(_searcher.Target);
    }

    public void Initialize()
    {
        _healthBar.Initialize(_health);
    }
}
