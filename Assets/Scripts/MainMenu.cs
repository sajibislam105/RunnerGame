using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

   public void QuitGame()
    {
        Application.Quit();
    }
   private void Start()
  {
    //  this.gameObject.SetActive(false);
  }
}
