using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //https://boxwitch.tistory.com/183
    Vector3 targetPos;
    Vector3 myPos;
    Vector3 newPos;

    public float bulletSpeed = 0.002f;

    void Start()
    {
        targetPos = GameObject.Find("Player").transform.position;

        myPos = transform.position;

        newPos = (targetPos - myPos) * bulletSpeed;
    }

    
    void Update()
    {
        transform.position = transform.position + newPos;
        if(this.transform.position.x <-10f)
        {
            Destroy(this.gameObject);
        }
    }


}
