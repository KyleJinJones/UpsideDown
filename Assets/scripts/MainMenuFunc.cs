using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunc : MonoBehaviour
{
    //Handles Most UI functionality, including loading scenes, and exiting the application
  public void loadllvl(int lvl)
    {
        SceneManager.LoadScene(lvl);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
