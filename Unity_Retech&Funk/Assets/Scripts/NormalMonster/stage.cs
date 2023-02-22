using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage : MonoBehaviour
{
    float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 10)
        {
            DestroyClone();
        }

    }

    public void DestroyClone()
    {
        GameObject[] clone = GameObject.FindGameObjectsWithTag("Enemy");

        for(int i =0; i<clone.Length; i++)
        {
            Destroy(clone[i]);
        }
    }
}
