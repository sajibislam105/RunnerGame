using UnityEngine;
using Zenject;

public class StarSpawner : MonoBehaviour
{
    [SerializeField] private CoinScript OrignalStarPrefab;
    [SerializeField] private Transform starContainerTransform;
    
    [Inject] private GameManager _gameManager;
    [Inject] private DiContainer _container;
    [Inject] private SignalBus _signalBus;

    private void Start()
    {
        _signalBus.Subscribe<RunnerGameSignals.CoinCollectSignal>(IncrementScore); //updating score
        SpawnStar(10); 
    }

    private void SpawnStar(int number)
    {
        for (int i = 0; i < number; i++)
        {
            var starClone = _container.InstantiatePrefab(OrignalStarPrefab.gameObject).GetComponent<CoinScript>();
            var starCloneTransform = starClone.transform;
            starCloneTransform.position = new Vector3((1), OrignalStarPrefab.transform.position.y, ((-40)+i)); //star position
            starCloneTransform.rotation = OrignalStarPrefab.transform.rotation;

            starClone.transform.parent = starContainerTransform.transform;
            starClone.name = "Star" + (i + 1);
        }
    }

    private void IncrementScore(RunnerGameSignals.CoinCollectSignal coinCollectSignal)
    {
        var score = coinCollectSignal.ScriptableObjectItemValue;
        //_gameManager.IncrementScore(10f);
        _gameManager.IncrementScore(score);
    }
}
