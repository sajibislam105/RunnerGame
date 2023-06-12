using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEnd : MonoBehaviour
{
    private AudioSource _audioSource;
    private MeshRenderer _meshRenderer;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name != "Player")
        {
            Debug.Log("Level complete");
            //gameObject.SetActive(false);
            _meshRenderer.enabled = false;  // disabling the wall's mesh rendering
             Invoke("Restart", 4.0f);
        }
        _audioSource.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        _audioSource=GetComponent<AudioSource>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
