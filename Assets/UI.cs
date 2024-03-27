using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{

    public GameObject fadeEffect;


    public void Startlevel()
    {
        fadeEffect.SetActive(true);

        this.Wait(2f, () => { SceneManager.LoadScene(1); });
    }

    
    public void MainMenu()
    {
        fadeEffect.SetActive(true);

        this.Wait(2f, () => { SceneManager.LoadScene(0); });
    }


    public void RestartLevel()
    {
        fadeEffect.SetActive(true);

        this.Wait(2f, () => { SceneManager.LoadScene(Application.loadedLevel); });
    }


    public void QuitGame()
    {
        fadeEffect.SetActive(true);

        this.Wait(2f, () => { Application.Quit(); });

        
    }


}
