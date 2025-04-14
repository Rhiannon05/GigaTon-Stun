using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public KeyCode triggerKey = KeyCode.E;

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(triggerKey))
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
}
