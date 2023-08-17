using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText1; //for the text UI
    [SerializeField] public GameObject mainMenu;
    public Text timeCountDown;

    private float _score;
    
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

    private void Update()
    {
        //function for activating the scene
        ActivateScore();
    }

    public void IncrementScore(float value)
    {
        _score = value + _score;
        scoreText1.text = "Score: " + _score;
    }

    private void DecrementScore()
    {
        _score--;
        scoreText1.text = "Score: " + _score;
    }

    public void EnableMainMenu()
    {
        mainMenu.SetActive(true);  //directly calling game object
    }
    //activating Score when game starts
    void ActivateScore()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            scoreText1.gameObject.SetActive(true);
        }
    }
    private void TimerCountDown(float time)
    {
        timeCountDown.text ="Time " +  time;
    }
}
