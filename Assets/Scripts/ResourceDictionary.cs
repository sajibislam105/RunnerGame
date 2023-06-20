using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDictionary : MonoBehaviour
{
    private Dictionary<Item_SO, float> resourceContainer = new Dictionary<Item_SO, float>();

    public void resourceManagement(Item_SO itemSo, float value)
    {
        if (resourceContainer.ContainsKey(itemSo))
        {
            resourceContainer[itemSo] += value;
        }
        else
        {
            resourceContainer.Add(itemSo,value);
        }
    }

    /*
    public float GetResourceDetails(Item_SO itemSo)
    {
        Debug.Log(resourceContainer[itemSo]);
        return resourceContainer[itemSo];
    }
    */
}
