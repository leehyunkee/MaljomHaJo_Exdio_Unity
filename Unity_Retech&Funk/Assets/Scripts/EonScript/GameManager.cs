using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject EndImg;
    bool escapeKey = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(escapeKey == false)
            {
                EndImg.SetActive(true);
                escapeKey = true;
            }
            else
            {
                EndImg.SetActive(false);
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
        EndImg.SetActive(false);
        escapeKey = false;
    }
}
