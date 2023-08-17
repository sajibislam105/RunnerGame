using System.Collections.Generic;
using UnityEngine;

public class ListofResource : MonoBehaviour
{
    private List<string> _itemList = new List<string>();

    public void AddToList(string name)
    {
       _itemList.Add(name);
    }
    public void GetList()
    {
        for(int i=0;i<_itemList.Count;i++)
        {
            //Debug.Log(itemList[i] + " " +itemList.Count);
        }
    }
}
