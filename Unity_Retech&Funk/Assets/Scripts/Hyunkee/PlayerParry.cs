/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParry : MonoBehaviour
{
    public GameObject bullet;
    public Transform pos;
    public float cooltime;
    private float curtime;
    PlayerAttack playerAttack;
    private void Awake()
    {
        playerAttack = GameObject.Find("Player").GetComponent<PlayerAttack>();
        //Ư�� ��ũ��Ʈ�� �ҷ����� ���� �ڵ�
    }

    private void Update()
    {
        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);
        if (curtime <= 0)
        {
            //���콺 ���� ��ư ���� ��
            if (Input.GetMouseButtonDown(0) && playerAttack.isParry == true)//�ڵ� ���� ������ .�� �̿��� ������
            {
                Instantiate(bullet, parrypos.position, transform.rotation);
                playerAttack.IsParryFalse();//��ũ��Ʈ ���� �Լ� ��������
            }
            curtime = cooltime;
        }
        curtime -= Time.deltaTime;

    }
}*/