using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void Game()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }
    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
