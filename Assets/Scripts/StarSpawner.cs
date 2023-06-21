using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class StarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject OrignalStar;
    [SerializeField] private GameObject StarContainer;

    private CoinScript _coinScript;
   [SerializeField] private GameManager _gameManager;
    private void Start()
    {
        SpawnStar(10);
    }

    void SpawnStar(int number)
    {
        for (int i = 0; i < number; i++)
        {
            GameObject StarClone = Instantiate(OrignalStar, new Vector3((1), OrignalStar.transform.position.y, ((-40)+i)), OrignalStar.transform.rotation);
            _coinScript = StarClone.GetComponent<CoinScript>();
            _coinScript.coinCollectAction += incrementScore;//_gameManager.IncrementScore;
            StarClone.transform.parent = StarContainer.transform;
            StarClone.name = "Star" + (i + 1);
        }
    }

    void incrementScore(float value)
    {
        _gameManager.IncrementScore(10f);
    }

}
