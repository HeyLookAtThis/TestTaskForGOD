using UnityEngine;

public class Automat : MonoBehaviour
{
    [SerializeField] private AutomatConfig _config;
    [SerializeField] private Transform _bulletStorage;

    private Magazine _magazine;

    private void Awake()
    {
        _magazine = new Magazine(_config.MagazineConfig, _bulletStorage, _config.Bullet);
        _magazine.Initialize(_config.BulletConfig);
    }

    public void Fire(Target target)
    {
        if (target == null) return;
        _magazine.GetBullet().SetTarget(target);
    }
}
