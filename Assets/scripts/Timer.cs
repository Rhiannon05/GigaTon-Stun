using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    public float maxTime = 180.0f;
    private float timeLeft;
    private string TimerText;




    private void Awake()
    {
        timeLeft = maxTime;
    }
    void FixedUpdate()
    {
        timeLeft -= Time.deltaTime;
        //Debug.Log(timeLeft);
        TimerText = System.Math.Round(timeLeft, 0).ToString();
        Debug.Log(TimerText);
        timerText = this.GetComponent<TextMeshProUGUI>();
        timerText.text = TimerText;
        int secondsToDisplay = (int)(timeLeft % 60);
        if (timeLeft <= 0)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        SceneManager.LoadScene("LoseScreen");
    }

}

