using Fusion;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(NetworkRunner))]
public class NetworkRunnerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<NetworkRunner>().FromInstance(GetComponent<NetworkRunner>()).AsSingle();
    }
}