using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void Startlevel()
    {
        SceneManager.LoadScene(1);
    }


    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene(Application.loadedLevel);
    }


    public void QuitGame()
    {
        Application.Quit();
    }


}
