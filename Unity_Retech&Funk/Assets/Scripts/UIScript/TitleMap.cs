using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMap : MonoBehaviour
{
   public void ChangeScene()
    {
        SceneManager.LoadScene("Eon");
    }

    public void End()
    {
        Application.Quit();
    }
}
