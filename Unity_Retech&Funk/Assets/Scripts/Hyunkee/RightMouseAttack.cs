using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMouseAttack : MonoBehaviour
{
    private float curTime;
    public float coolTime = 0.5f;
    public Transform pos;
    public Vector2 boxSize;

    private float ComboCount = 3;
    public float UpdateComboCount = 3;
    private float comboCurTime;
    public float comboCoolTime;

    private PlayerParry parrying;
    private void Awake()
    {
        parrying = GameObject.Find("ParryPos").GetComponent<PlayerParry>();
        //Ư�� ��ũ��Ʈ�� �ҷ����� ���� �ڵ�
    }

  //public bool parryBullet = false;

    private void Update()
    {
        if (curTime <= 0 && comboCurTime <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ComboCount-=1;
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
                foreach (Collider2D collider in collider2Ds)
                {
                    Debug.Log(collider.gameObject.tag);
                    if (collider.gameObject.tag == "Enemy")     //�ڽ� ������ ������ ��ü�� tag == Enemy(���)�� ��� 
                    {
                        Debug.Log("������ ������");
                    }
                    else if (collider.gameObject.tag == "parry")//�ڽ� ������ ������ ��ü�� tag == parry(�и� ������ ź��)�� ���
                    {
                        Debug.Log("�и� ����");
                        Destroy(collider.gameObject);           //ź�� �Ҹ�
                        //isParryTrue();
                        parrying.parryTrue();
                    }
                    
                }
                curTime = coolTime;
            }
            
            
            if (ComboCount <= 0)
            {
                comboCurTime = comboCoolTime;
                ComboCount = UpdateComboCount;
            }
        }
        else
        {
            curTime -= Time.deltaTime;
            comboCurTime -= Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        //���� ������ Ȯ���� ���� �־�� �ڵ�
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
    /*public void isParryTrue()
    {
        parryBullet = true;
    }
    public void isParryFalse()
    {
        parryBullet = false;
    }*/
}