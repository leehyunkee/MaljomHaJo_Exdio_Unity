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
            //collision�� �浹ü�� ������ �� ��������. => �΋H�� gameobject ��ü�� �ٷ� ���� �� ����

            Destroy(collision.gameObject);
            Debug.Log("�� ���");
            Dead();
            

        }
       

    }
    void Dead()
    {
        Destroy(gameObject);
    }
}
