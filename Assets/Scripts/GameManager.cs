using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int score = 0;

    public static GameManager inst;
    public Text scoreText1; //for the text UI
 
    public void IncrementScore()
    {
        score++;
        scoreText1.text = "Score: " + score;
    }

    public void DecrementScore()
    {
        score--;
        scoreText1.text = "Score: " + score;
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
