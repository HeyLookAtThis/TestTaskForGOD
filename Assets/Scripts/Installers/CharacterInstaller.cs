using UnityEngine;
using Zenject;

public class CharacterInstaller : MonoInstaller
{
    [SerializeField] private Character _prefab;
    [SerializeField] private Transform _spawnPoint;

    public override void InstallBindings()
    {
        BindPlayer();
    }

    private void BindPlayer()
    {
        Character character = Container.InstantiatePrefabForComponent<Character>(_prefab, _spawnPoint.position, Quaternion.identity, null);
        character.Initialize();
        Container.BindInterfacesAndSelfTo<Character>().FromInstance(character).AsSingle();
    }
}
