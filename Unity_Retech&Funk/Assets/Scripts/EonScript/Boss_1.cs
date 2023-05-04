using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1 : MonoBehaviour
{
    //public GameObject playerObject;
    public GameObject bulletPrefab;
    public GameObject sprinkleBullet;
    public GameObject gun;
    public GameObject mobs;

    GameObject player;
    Animator gunFireAnim;

    //public GameObject mob;
    float timeCheck;
    bool goRush = false;
    bool bossStart = true;

    public int bossHealth = 10;
    public int phaseHealth;

    public float minigunXPos = 2f;

    Vector3 direction;
    void Start()
    {
        StartCoroutine("MakeBullet");
        player = GameObject.FindWithTag("Player");
        phaseHealth = bossHealth / 2;
        gunFireAnim = gun.GetComponent<Animator>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="PlayerBullet")
        {
            bossHealth--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(bossStart)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(2.53f, 0, 0), 
                5 * Time.deltaTime);

            if (transform.position.x <= 2.53f) 
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
        gunFireAnim.SetTrigger("Fire");
        Vector3 sprinklePosition = new Vector3(gun.transform.position.x- minigunXPos, gun.transform.position.y, 0);
        GameObject bullet = Instantiate(sprinkleBullet, sprinklePosition, Quaternion.identity);
        bullet.transform.localScale = new Vector3(1, 1, 1);
        yield return null;
        
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
        transform.position = new Vector3(12.3f, 0, 0);
        bossStart = true;
        yield return null;

        
    }

    public IEnumerator PhaseCheck()
    {
        Vector3 targetPosition = new Vector2(transform.position.x - 2f, mobs.transform.position.y);
        if(bossHealth<=5)
        {
            mobs.SetActive(true);
            while(mobs.transform.position !=targetPosition)
            {
                mobs.transform.position = Vector3.MoveTowards(mobs.transform.position, targetPosition, 1f * Time.deltaTime);
                yield return null;
            }
        }
    }
   
}
