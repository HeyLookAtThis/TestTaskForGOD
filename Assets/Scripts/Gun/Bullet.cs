using UnityEngine;

public class Bullet : MonoBehaviour
{
    private BulletConfig _config;
    private Target _target;

    public float Damage => _config.Damage;
    public bool IsAllowed { get; private set; }

    private void Update()
    {
        if (gameObject.activeSelf)
            return;

        Fly();
    }


    public void Initialize(BulletConfig config)
    {
        _config = config;
        Disable();
    }

    public void SetTarget(Target target)
    {
        Enable();
        _target = target;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Mutant>(out Mutant mutant))
        {
            mutant.Health.TakeDamage(Damage);
            Disable();
        }
    }

    private void Fly() => transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, _config.Speed * Time.deltaTime);

    private void Enable()
    {
        if (IsAllowed)
        {
            gameObject.SetActive(true);
            IsAllowed = false;
        }
    }

    private void Disable()
    {
        gameObject.SetActive(false);
        transform.position = Vector2.zero;
        IsAllowed = true;
        _target = null;
    }
}
