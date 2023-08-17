using System.Collections.Generic;
using UnityEngine;

public class ResourceDictionary : MonoBehaviour
{
    private Dictionary<Item_SO, float> _resourceContainer = new Dictionary<Item_SO, float>();

    public void ResourceManagement(Item_SO itemSo, float value)
    {
        if (_resourceContainer.ContainsKey(itemSo))
        {
            _resourceContainer[itemSo] += value;
        }
        else
        {
            _resourceContainer.Add(itemSo,value);
        }
    }
}
