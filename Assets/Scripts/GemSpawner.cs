using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject OrignalGem;
    [SerializeField] private GameObject GemContainer;

    private CoinScript _coinScript;
   [SerializeField] private GameManager _gameManager;
    private void Start()
    {
        SpawnGem(5);
    }
    void SpawnGem(int number)
    {
        for (int i = 0; i < number; i++)
        {
            GameObject GemClone = Instantiate(OrignalGem, new Vector3((-2.5f), OrignalGem.transform.position.y, ((-30)+i)), OrignalGem.transform.rotation);
            _coinScript = GemClone.GetComponent<CoinScript>();
            _coinScript.coinCollectAction += incrementScore;
            GemClone.transform.parent = GemContainer.transform;
            GemClone.name = "Gem" + (i + 1);
        }
    }
    
    void incrementScore(float value)
    {
        _gameManager.IncrementScore(10f);
    }
}
