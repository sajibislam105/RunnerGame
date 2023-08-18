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
        Container.Bind<Rigidbody>().FromComponentSibling().AsTransient();
        
        SignalBusInstaller.Install(Container);
        
        //coin scripts signals
        Container.DeclareSignal<RunnerGameSignals.CoinCollectSignal>();
        
        //ObstacleScript script signal
        Container.DeclareSignal<RunnerGameSignals.DecrementScoreSignal>();
        
        //PlayerMovement script signal
        Container.DeclareSignal<RunnerGameSignals.TimerCounterSignal>();


    }
}