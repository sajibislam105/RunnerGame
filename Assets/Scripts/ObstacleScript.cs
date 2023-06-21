using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public static Action DecrementAction;
    private AudioSource _audioSource;

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
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
}
