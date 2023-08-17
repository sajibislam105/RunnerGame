using System;
using UnityEngine;
using Zenject;

public class ObstacleScript : MonoBehaviour
{
    public static Action DecrementAction;
    [Inject]private AudioSource _audioSource;

    void TriggerDecrementAction()
    {
        DecrementAction?.Invoke();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name != "Player")
        {
            _audioSource.Play();
            TriggerDecrementAction();
            //GameManager.inst.DecrementScore();
        }
    }
}
