using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1 : MonoBehaviour
{
    //public GameObject playerObject;
    public GameObject bulletPrefab;


    void Start()
    {
        StartCoroutine("MakeBullet");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MakeBullet()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject bullet = Instantiate(bulletPrefab, transform.position,Quaternion.identity);
        StartCoroutine("MakeBullet");
    }
}
