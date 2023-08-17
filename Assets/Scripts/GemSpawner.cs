using UnityEngine;
using Zenject;

public class GemSpawner : MonoBehaviour
{
    [Inject] private GameManager _gameManager;
    [Inject] private DiContainer _container;
    
    [SerializeField] private CoinScript originalGemPrefab;
    [SerializeField] private Transform gemContainerTransform;

    private void Start()
    {
        SpawnGem(5);
    }
    void SpawnGem(int number)
    {
        for (int i = 0; i < number; i++)
        {
            var gemClone = _container.InstantiatePrefab(originalGemPrefab.gameObject).GetComponent<CoinScript>();
            var gemCloneTransform = gemClone.transform;
            gemCloneTransform.position = new Vector3((-2.5f), originalGemPrefab.transform.position.y, ((-30) + i));
            gemCloneTransform.rotation = originalGemPrefab.transform.rotation;
            
            gemClone.coinCollectAction += IncrementScore;
            gemClone.transform.parent = gemContainerTransform.transform;
            gemClone.name = "Gem" + (i + 1);
        }
    }
    private void IncrementScore(float value)
    {
        _gameManager.IncrementScore(10f);
    }
}
