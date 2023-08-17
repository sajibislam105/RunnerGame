using UnityEngine;
using Zenject;

public class StarSpawner : MonoBehaviour
{
    [Inject] private GameManager _gameManager;
    [Inject] private DiContainer _container;
    
    [SerializeField] private CoinScript OrignalStarPrefab;
    [SerializeField] private Transform starContainerTransform;

    private void Start()
    {
        SpawnStar(10);
    }

    void SpawnStar(int number)
    {
        for (int i = 0; i < number; i++)
        {
            var starClone = _container.InstantiatePrefab(OrignalStarPrefab.gameObject).GetComponent<CoinScript>();
            var starCloneTransform = starClone.transform;
            starCloneTransform.position = new Vector3((1), OrignalStarPrefab.transform.position.y, ((-40)+i)); //star position
            starCloneTransform.rotation = OrignalStarPrefab.transform.rotation;
            
            starClone.coinCollectAction += IncrementScore;//_gameManager.IncrementScore;
            starClone.transform.parent = starContainerTransform.transform;
            starClone.name = "Star" + (i + 1);
        }
    }

    void IncrementScore(float value)
    {
        _gameManager.IncrementScore(10f);
    }
}
