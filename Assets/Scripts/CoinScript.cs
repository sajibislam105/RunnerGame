using System;
using UnityEngine;
using Zenject;

public class CoinScript : MonoBehaviour
{
    //public UnityEvent<float> coinCollectEvent;   //unity event action
    public  Action<float> coinCollectAction;
    
    [Inject] private AudioSource _audioSource;
    [Inject] private MeshRenderer _meshRenderer;
    [Inject] private ParticleSystem _particleSystem;

    private const float RotateSpeed = 90.0f;
    
    //scriptable object
    [SerializeField] private Item_SO _itemSo; // referencing scriptable object
    
    //getting reference so that it can access the dictionary class
    [SerializeField]private ResourceDictionary _resourceDictionary;
    
    //getting reference so that it can access the list class
    [SerializeField]private ListofResource _listofResource;

    void Update()
    {
        transform.Rotate(0,0,RotateSpeed* Time.deltaTime);
    }

    void OnTriggerIncrement()
    {
        coinCollectAction?.Invoke(_itemSo._itemValue); //S.O. value
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name != "Player")
        {
            // gameManager.IncrementScore(_itemSo._itemValue);
            //coinCollectEvent.Invoke(_itemSo._itemValue);

            //GameManager.inst.IncrementScore(_itemSo._itemValue);   // sending the value of S.O. items value using parameter
            OnTriggerIncrement();
            _meshRenderer.enabled = false; // disable the visual first
            _audioSource.clip = _itemSo._ItemAudioClip;  //took from S.O. set the audio clip into the Audio source 
            _audioSource.Play(); // plays sound
            _particleSystem.Play(); // plays when touch the coin
            
            //_resourceDictionary.resourceManagement(_itemSo, _itemSo._itemValue); // sending the S.O. and it's itemValue.
            //  _resourceDictionary.GetResourceDetails(_itemSo); //to check if it is added in the dictionary
            
          _listofResource.AddToList(_itemSo._itemName); //adding item name to the list sequentially.
          _listofResource.GetList();
            //Destroy(gameObject, 5.0f); // objects will be destroyed after 5 seconds
        }
    }
}
