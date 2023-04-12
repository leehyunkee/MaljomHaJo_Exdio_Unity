using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject StopImg;
    public GameObject stageStartImg;
    public GameObject bossWarning;

    Animator stageAnim;
    Animator warningAnim;
    bool escapeKey = false;
    bool bossStart = false;

    public float waitTime = 10f;

    public GameObject theBoss;

    private void Start()
    {
        stageAnim = stageStartImg.GetComponent<Animator>();
        warningAnim = bossWarning.GetComponent<Animator>();
        StartCoroutine(StartStageAnim());
        //StartCoroutine(StartBoss());
    }

    IEnumerator StartBoss()
    {
        //yield return new WaitForSeconds(waitTime);
        bossWarning.SetActive(true);
        warningAnim.SetTrigger("Warning");
        yield return new WaitForSeconds(3.5f);
        bossWarning.SetActive(false);
        theBoss.SetActive(true);
        bossStart = true;
    }

    IEnumerator StartStageAnim()
    {
        stageStartImg.SetActive(true);
        stageAnim.SetTrigger("StartStage1");
        //yield return new WaitForSeconds(0.01f);

        //float curAnimationTime = stageAnim.GetCurrentAnimatorStateInfo(0).length;

        yield return new WaitForSeconds(2f);
        stageStartImg.SetActive(false);
      

    }
    private void Update()
    {
        if ((int)GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && bossStart == false)
        {
            StartCoroutine(StartBoss());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (escapeKey == false)
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
