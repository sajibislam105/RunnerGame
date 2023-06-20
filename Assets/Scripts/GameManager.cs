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
    public Text timeCountDown;
    
   
    float score = 0;
    public void IncrementScore(float value)
    {
        score = value + score;
        scoreText1.text = "Score: " + score;
    }

    public void DecrementScore()
    {
        score--;
        scoreText1.text = "Score: " + score;
    }

    public void enableMainMenu()
    {
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

   
    public void TimerCountDown(float time)
    {
        timeCountDown.text ="Time " +  time.ToString();
    }
    
 
    void Update()
    {
       //function for activating the scene
        activateScore();
    }
}
