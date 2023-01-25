using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject StopImg;
    public GameObject stageStartImg;
    Animator stageAnim;
    bool escapeKey = false;

    private void Start()
    {
        stageAnim = stageStartImg.GetComponent<Animator>();
        stageStartImg.SetActive(true);
        StartCoroutine(StartStageAnim());
    }

    IEnumerator StartStageAnim()
    {
        stageAnim.SetTrigger("StartStage1");
        yield return new WaitForSeconds(0.01f);

        float curAnimationTime = stageAnim.GetCurrentAnimatorStateInfo(0).length;

        yield return new WaitForSeconds(curAnimationTime);
        stageStartImg.SetActive(false);
      

    }
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
