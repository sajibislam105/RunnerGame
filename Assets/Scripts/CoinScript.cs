using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private float rotatespeed = 90.0f;

    private AudioSource _audioSource;
    private MeshRenderer _meshRenderer;
    private ParticleSystem _particleSystem;
    
    //scriptable object
    [SerializeField] private Item_SO _itemSo; // referencing scriptable object
    
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name != "Player")
        {
            /*
             if (CompareTag("Star"))
            {
                GameManager.inst.IncrementScore();    
            }
            /*/
            GameManager.inst.IncrementScore();
            _meshRenderer.enabled = false; // disable the visual first
            _audioSource.clip = _itemSo._ItemAudioClip;  //took from S.O. set the audio clip into the Audio source 
            _audioSource.Play(); // plays sound
            _particleSystem.Play(); // plays when touch the coin
            //Destroy(gameObject, 5.0f); // objects will be destroyed after 5 seconds
return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,rotatespeed* Time.deltaTime);
    }
}
