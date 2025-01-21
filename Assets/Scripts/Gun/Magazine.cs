using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Magazine
{
    private MagazineConfig _config;
    private Transform _storage;
    private Bullet _bulletPrefab;
    private List<Bullet> _bullets;

    public Magazine(MagazineConfig config, Transform transform, Bullet bullet)
    {
        _config = config;
        _storage = transform;
        _bulletPrefab = bullet;
    }

    public void Initialize(BulletConfig bulletConfig)
    {
        _bullets = new List<Bullet>();

        int bulletCount = 0;

        while (bulletCount < _config.Capacity)
        {
            Bullet bullet = Object.Instantiate(_bulletPrefab, _storage);
            bullet.Initialize(bulletConfig);
            _bullets.Add(bullet);
            bulletCount++;
        }
    }

    public Bullet GetBullet()
    {
        var bullet = _bullets.FirstOrDefault(bullet => bullet.IsAllowed);
        return bullet;
    }
}
