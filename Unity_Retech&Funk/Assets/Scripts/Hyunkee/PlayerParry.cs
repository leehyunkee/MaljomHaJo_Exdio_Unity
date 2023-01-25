using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParry : MonoBehaviour
{
    public GameObject bullet;
    public Transform parrypos;
    public float cooltime;
    private float curtime;

    public bool isParry = false;

    private RightMouseAttack playerAttack;
    private void Awake()
    {
        playerAttack = GameObject.Find("Player").GetComponent<RightMouseAttack>();
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
            if (isParry == true)//�ڵ� ���� ������ .�� �̿��� ������
            {
                Instantiate(bullet, parrypos.position, transform.rotation);
                parryFalse();
                //playerAttack.isParryFalse();
            }
            curtime = cooltime;
        }
        curtime -= Time.deltaTime;

    }
    public void parryTrue()
    {
        isParry = true;
    }
    public void parryFalse()
    {
        isParry = false;
    }
}