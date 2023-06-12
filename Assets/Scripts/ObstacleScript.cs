using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    private AudioSource _audioSource;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name != "Player")
        {
            _audioSource.Play();
            GameManager.inst.DecrementScore();
        }
    }
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
