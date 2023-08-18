using System;
using UnityEngine;
using Zenject;

public class ObstacleScript : MonoBehaviour
{
    [Inject]private AudioSource _audioSource;
    [Inject] private SignalBus _signalBus;

    private void TriggerDecrementScoreSignal()
    {
        _signalBus.Fire(new RunnerGameSignals.DecrementScoreSignal());
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name != "Player")
        {
            _audioSource.Play();
            TriggerDecrementScoreSignal();
            //GameManager.inst.DecrementScore();
        }
    }
}
