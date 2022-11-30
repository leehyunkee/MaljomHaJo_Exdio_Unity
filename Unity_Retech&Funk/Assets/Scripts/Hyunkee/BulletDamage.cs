using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    
    public Animator anim;
    public GameObject obj;
    
    


    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (obj.GetComponent<PlayerHealth>().isHurt == false && collision.tag == ("Player"))
        {                      
            obj = GameObject.Find("Player");
            obj.GetComponent<PlayerHealth>().TakeDamage(1);
            obj.GetComponent<PlayerHealth>().Hurt();
            DestroyBullet();
        }
        
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }

}
