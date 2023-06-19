using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager inst;
    public Text scoreText1; //for the text UI
    public GameObject mainMenu;
    
    //reference from S.O.
    [SerializeField] private Item_SO _itemSo;

    float score = 0;
    public void IncrementScore()
    {
        score = _itemSo._itemValue + score;
        scoreText1.text = "Score: " + score;
    }

    public void DecrementScore()
    {
        score = _itemSo._itemValue - score;;
        scoreText1.text = "Score: " + score;
    }

    public void enableMainMenu()
    {
        Debug.Log("reached the Menu");
        mainMenu.SetActive(true);  //directly calling game object
        
    }
    private void Awake()
    {
        inst = this;
    }
    
    //activating Score when game starts
    void activateScore()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            scoreText1.gameObject.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       //function for activating the scene
        activateScore();
    }
}
