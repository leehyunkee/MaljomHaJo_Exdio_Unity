using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject StopImg;
    bool escapeKey = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(escapeKey == false)
            {
                StopImg.SetActive(true);
                escapeKey = true;
            }
            else
            {
                StopImg.SetActive(false);
                escapeKey = false;
            }
            
            
        }

    }

    public void End()
    {
        Application.Quit();
    }

    public void Continue()
    {
        StopImg.SetActive(false);
        escapeKey = false;
    }

    public void Title()
    {
        SceneManager.LoadScene("Title");
    }
}
