using UnityEngine;
using Zenject;

public class RunnerGameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameManager>().FromComponentInHierarchy().AsSingle();
        
        Container.Bind<AudioSource>().FromComponentSibling().AsTransient(); //because different scripts have different audioSource
        Container.Bind<MeshRenderer>().FromComponentSibling().AsTransient();
        Container.Bind<ParticleSystem>().FromComponentSibling().AsTransient();
    }
}