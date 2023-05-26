using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void MenuToGame()
    {
        SceneManager.LoadScene(2);
    }

    public void MenuToControls()
    {
        SceneManager.LoadScene(1);
    }

    public void ControlsToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
