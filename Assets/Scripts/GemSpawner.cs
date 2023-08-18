using UnityEngine;
using Zenject;

public class GemSpawner : MonoBehaviour
{
    [SerializeField] private CoinScript originalGemPrefab;
    [SerializeField] private Transform gemContainerTransform;
    
    [Inject] private GameManager _gameManager;
    [Inject] private DiContainer _container;
    [Inject] private SignalBus _signalBus;

    private void Start()
    {
        _signalBus.Subscribe<RunnerGameSignals.CoinCollectSignal>(IncrementScore); //updating score
        SpawnGem(5);
    }
    private void SpawnGem(int number)
    {
        for (int i = 0; i < number; i++)
        {
            var gemClone = _container.InstantiatePrefab(originalGemPrefab.gameObject).GetComponent<CoinScript>();
            var gemCloneTransform = gemClone.transform;
            gemCloneTransform.position = new Vector3((-2.5f), originalGemPrefab.transform.position.y, ((-30) + i));
            gemCloneTransform.rotation = originalGemPrefab.transform.rotation;

            gemClone.transform.parent = gemContainerTransform.transform;
            gemClone.name = "Gem" + (i + 1);
        }
    }
    private void IncrementScore(RunnerGameSignals.CoinCollectSignal coinCollectSignal)
    {
        var score = coinCollectSignal.ScriptableObjectItemValue;
        //_gameManager.IncrementScore(10f);
        _gameManager.IncrementScore(score);
    }
}
