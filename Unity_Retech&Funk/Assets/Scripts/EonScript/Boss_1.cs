using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1 : MonoBehaviour
{
    //public GameObject playerObject;
    public GameObject bulletPrefab;
    GameObject player;
    void Start()
    {
        StartCoroutine("MakeBullet");
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            rush();
        }
        
    }

    IEnumerator MakeBullet()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject bullet = Instantiate(bulletPrefab, transform.position,Quaternion.identity);
        StartCoroutine("MakeBullet");
    }

    void rush()
    {
        Vector3 direction = player.transform.position - this.transform.position;
        this.transform.position += direction * 0.001f;
    }
}
