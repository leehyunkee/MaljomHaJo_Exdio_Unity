using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("PlayerBullet") || collision.gameObject.tag == ("PlayerATK"))
        {
            //collision이 충돌체의 정보를 다 갖고있음. => 부딫힌 gameobject 자체를 바로 없앨 수 있음

            Destroy(collision.gameObject);
            Debug.Log("적 사망");
            Dead();
            

        }
       

    }
    void Dead()
    {
        Destroy(gameObject);
    }
}
