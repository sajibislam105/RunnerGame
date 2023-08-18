using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    public Text scoreText1; //for the text UI
    public Text timeCountDown;

    [Inject] private SignalBus _signalBus;
    
    private float _score;
    
    private void OnEnable()
    {
        _signalBus.Subscribe<RunnerGameSignals.DecrementScoreSignal>(DecrementScore);
        _signalBus.Subscribe<RunnerGameSignals.TimerCounterSignal>(TimerCountDown);
    }

    private void OnDisable()
    {
        _signalBus.Unsubscribe<RunnerGameSignals.DecrementScoreSignal>(DecrementScore);
        _signalBus.Unsubscribe<RunnerGameSignals.TimerCounterSignal>(TimerCountDown);
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
    private void TimerCountDown(RunnerGameSignals.TimerCounterSignal timerCounterSignal)
    {
        var time = timerCounterSignal.TimeCount;
        timeCountDown.text ="Time " +  time;
    }
}
