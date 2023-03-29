using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1 : MonoBehaviour
{
    //public GameObject playerObject;
    public GameObject bulletPrefab;
    public GameObject sprinkleBullet;
    public GameObject gun;
    GameObject player;
    //public GameObject mob;
    float timeCheck;
    bool goRush = false;
    bool bossStart = true;

   
    Vector3 direction;
    void Start()
    {
        StartCoroutine("MakeBullet");
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(bossStart)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(5.5f, 0, 0), 
                5 * Time.deltaTime);

            if (transform.position.x <= 5.5f) 
                bossStart = false;
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {

           // direction = player.transform.position - this.transform.position;
            //goRush = true;
            StartCoroutine(rush());
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(Sprinkle());
        }
        
        if(goRush)
        {
            //Vector3 direction = player.transform.position - this.transform.position;
            direction.Normalize();
           // this.transform.position = this.transform.position + direction*5  * Time.deltaTime;
            
            //mob.transform.position = mob.transform.position + direction * 0.01f * Time.deltaTime;
            Debug.Log("1");
            
        }
    }

    IEnumerator Sprinkle()
    {
        yield return new WaitForSeconds(1f);
        GameObject bullet = Instantiate(sprinkleBullet, transform.position, Quaternion.identity);
        bullet.transform.localScale = new Vector3(1, 1, 1);
        
    }
    IEnumerator MakeBullet()
    {
        yield return new WaitForSeconds(1.3f);
        GameObject bullet = Instantiate(bulletPrefab, transform.position,Quaternion.identity);
        StartCoroutine("MakeBullet");
    }

    IEnumerator rush()
    {
        direction = player.transform.position - this.transform.position;
        
        direction.Normalize();
        direction.x = -33f;
        while (this.gameObject.transform.position.x > -30f)
        {
            Debug.Log(direction);
            //this.transform.position = this.transform.position + direction * 0.01f * Time.deltaTime;
            //mob.transform.position = mob.transform.position + direction * 0.01f * Time.deltaTime;
            //gameObject.transform.Translate(direction);
            transform.position = Vector3.MoveTowards(transform.position, direction, 0.1f);
            Debug.Log("1");
            yield return new WaitForSeconds(0.01f);
        }
        transform.position = new Vector3(gun.transform.position.x, gun.transform.position.y, 0);
        bossStart = true;
        yield return null;

        
    }
   
}
