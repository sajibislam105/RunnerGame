using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   // public static GameManager inst;
    public Text scoreText1; //for the text UI
    public GameObject mainMenu;
    public Text timeCountDown;

    float score = 0;
    //[SerializeField] private CoinScript _coinScript;
    private void OnEnable()
    { 
        ObstacleScript.DecrementAction += DecrementScore;
        PlayerMovement.TimeCounterAction += TimerCountDown;
    }

    private void OnDisable()
    {
        ObstacleScript.DecrementAction -= DecrementScore;
        PlayerMovement.TimeCounterAction -= TimerCountDown;
    }
    
    void Update()
    {
        //function for activating the scene
        activateScore();
    }

    public void IncrementScore(float value)
    {
        score = value + score;
        scoreText1.text = "Score: " + score;
    }

    private void DecrementScore()
    {
        score--;
        scoreText1.text = "Score: " + score;
    }

    public void enableMainMenu()
    {
        mainMenu.SetActive(true);  //directly calling game object
    }
    //activating Score when game starts
    void activateScore()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            scoreText1.gameObject.SetActive(true);
        }
    }
    private void TimerCountDown(float time)
    {
        timeCountDown.text ="Time " +  time.ToString();
    }
}
