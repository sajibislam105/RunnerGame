using Zenject;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class LevelEnd : MonoBehaviour
{
    [Inject] private GameManager _gameManager;
    [SerializeField] private CinemachineVirtualCamera zoomedCamera;

    [Inject]private AudioSource _audioSource;
    [Inject]private MeshRenderer _meshRenderer;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name != "Player")
        {
            Debug.Log("Level complete");
            //gameObject.SetActive(false);
            _meshRenderer.enabled = false;  // disabling the wall's mesh rendering
            // Invoke("Restart", 4.0f);
            if (_meshRenderer.enabled == false)
            {
                zoomedCamera.Priority = 11;
            }
            else
            {
                zoomedCamera.Priority = 0;
            }
        }
        _audioSource.Play();
        _gameManager.EnableMainMenu();
    }    
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
