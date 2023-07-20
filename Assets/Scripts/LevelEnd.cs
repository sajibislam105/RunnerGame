using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera zoomedCamera;
    
    private AudioSource _audioSource;
    private MeshRenderer _meshRenderer;
    [SerializeField] private GameManager _gameManager;
    

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
        _gameManager.enableMainMenu();
    }

    // Start is called before the first frame update
    void Start()
    {
        _audioSource=GetComponent<AudioSource>();
        _meshRenderer = GetComponent<MeshRenderer>();
        //_gameManager = GetComponent<GameManager>();
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
