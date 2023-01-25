using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1 : MonoBehaviour
{
    //public GameObject playerObject;
    public GameObject bulletPrefab;
    GameObject player;
    //public GameObject mob;
    float timeCheck;
    bool goRush = false;

    Vector3 direction;
    void Start()
    {
        StartCoroutine("MakeBullet");
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            
            direction = player.transform.position - this.transform.position;
            goRush = true;
        }
        
        if(goRush)
        {
            //Vector3 direction = player.transform.position - this.transform.position;
            direction.Normalize();
            this.transform.position = this.transform.position + direction*5  * Time.deltaTime;
            //mob.transform.position = mob.transform.position + direction * 0.01f * Time.deltaTime;
            Debug.Log("1");
            
        }
    }

    IEnumerator MakeBullet()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject bullet = Instantiate(bulletPrefab, transform.position,Quaternion.identity);
        StartCoroutine("MakeBullet");
    }

    IEnumerator rush()
    {
        Vector3 direction = player.transform.position - this.transform.position;
        direction.Normalize();
        while (this.gameObject.transform.position.x > -30f)
        {
            this.transform.position = this.transform.position + direction * 0.01f * Time.deltaTime;
            //mob.transform.position = mob.transform.position + direction * 0.01f * Time.deltaTime;
            Debug.Log("1");
        }

        yield return null;
    }
   
}
