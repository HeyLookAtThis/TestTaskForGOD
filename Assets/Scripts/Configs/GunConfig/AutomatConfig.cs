using UnityEngine;

[CreateAssetMenu(fileName = "AutomatConfig", menuName = "Configs/AutomatCongfig")]
public class AutomatConfig : ScriptableObject
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private MagazineConfig _magazineConfig;
    [SerializeField] private BulletConfig _bulletConfig;

    public Bullet Bullet => _prefab;
    public MagazineConfig MagazineConfig => _magazineConfig;
    public BulletConfig BulletConfig => _bulletConfig;
}
