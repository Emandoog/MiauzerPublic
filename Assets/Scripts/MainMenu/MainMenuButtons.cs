using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{

    public void PlayGame() 
    {
        SceneManager.LoadScene(1);

    }
    public void OpenOptions()
    {
        //SceneManager.LoadScene(0);

    }
    public void QuitGame()
    {
        Application.Quit();

    }
    public void OpenCredits()
    {
        SceneManager.LoadScene(2);

    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);

    }
}
