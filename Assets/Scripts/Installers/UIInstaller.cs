using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField] private FireButton _fireButton;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<FireButton>().FromInstance(_fireButton).AsSingle();
    }
}
