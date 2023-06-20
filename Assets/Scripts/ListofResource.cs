using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListofResource : MonoBehaviour
{
    private List<string> itemList = new List<string>();

    public void addToList(string name)
    {
       itemList.Add(name);
       return;
    }

    public void GetList()
    {
        for(int i=0;i<itemList.Count;i++)
        {
            Debug.Log(itemList[i] + " " +itemList.Count);
        }
        return;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
