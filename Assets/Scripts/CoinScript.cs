using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CoinScript : MonoBehaviour
{
    public UnityEvent<float> coinCollectEvent;
    
    private float rotatespeed = 90.0f;

    private AudioSource _audioSource;
    private MeshRenderer _meshRenderer;
    private ParticleSystem _particleSystem;
    
    //scriptable object
    [SerializeField] private Item_SO _itemSo; // referencing scriptable object
    
    //getting reference so that it can access the dictionary class
    [SerializeField]private ResourceDictionary _resourceDictionary;
    
    //getting reference so that it can access the list class
    [SerializeField]private ListofResource _listofResource;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name != "Player")
        {
           // gameManager.IncrementScore(_itemSo._itemValue);
          coinCollectEvent.Invoke(_itemSo._itemValue);
            
            //GameManager.inst.IncrementScore(_itemSo._itemValue);   // sending the value of S.O. items value using parameter
            _meshRenderer.enabled = false; // disable the visual first
            _audioSource.clip = _itemSo._ItemAudioClip;  //took from S.O. set the audio clip into the Audio source 
            _audioSource.Play(); // plays sound
            _particleSystem.Play(); // plays when touch the coin
            
            //_resourceDictionary.resourceManagement(_itemSo, _itemSo._itemValue); // sending the S.O. and it's itemValue.
          //  _resourceDictionary.GetResourceDetails(_itemSo); //to check if it is added in the dictionary
            
          _listofResource.addToList(_itemSo._itemName); //adding item name to the list sequentially.
          _listofResource.GetList();
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
