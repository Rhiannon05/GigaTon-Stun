using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ChangeScene : MonoBehaviour
{
    public GameObject startButton, controlsButton, creditsButton, quitButton;

   
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
    public void TwoOrOne()
    {
        SceneManager.LoadScene("Single-TwoPlayer");
    }
    public void ABSOFight()
    {
        SceneManager.LoadScene("ABSOFight");
    }
    public void TinmanFight()
    {
        SceneManager.LoadScene("TinmanFight");
    }
    public void GaminFight()
    {
        SceneManager.LoadScene("GaminFight");
    }
    public void CharacterSelectSingle()
    {
        SceneManager.LoadScene("CharacterSelectSIngle");
    }
    public void Player1CharacterSelect()
    {
        SceneManager.LoadScene("CharacterSelectP1");
    }
    public void Player2CharacterSelect()
    {
        SceneManager.LoadScene("CharacterSelectP2");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
