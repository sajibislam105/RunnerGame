using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Object/Item")]
public class Item_SO : ScriptableObject
{
    public string _itemName;
    public float _itemValue;
    public AudioClip _ItemAudioClip;
    public Material _itemMaterial;
    public string _itemDescription;
}
