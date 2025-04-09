using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void Antartica()
    {
        SceneManager.LoadScene("Antartica");
    }
    public void Bridge()
    {
        SceneManager.LoadScene("Bridge");
    }
    public void Church()
    {
        SceneManager.LoadScene("Church");
    }
    public void Fields()
    {
        SceneManager.LoadScene("Fields");
    }
    public void Moon()
    {
        SceneManager.LoadScene("Moon");
    }
    public void Outback()
    {
        SceneManager.LoadScene("Outback");
    }
    public void Steakhouse()
    {
        SceneManager.LoadScene("Steakhouse");
    }
    public void Stadium()
    {
        SceneManager.LoadScene("Stadium");
    }
    public void BoxingRing()
    {
        SceneManager.LoadScene("BoxingRing");
    }
    public void Ruins()
    {
        SceneManager.LoadScene("Ruins");
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
