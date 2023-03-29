using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBullet_ : Bullet
{

    public GameObject circleBullet;
    protected override void Timer()
    {
        base.Timer();
        StartCoroutine(ReadyCircle());

    }

    IEnumerator ReadyCircle()
    {
        Debug.Log("hi");
        yield return new WaitForSeconds(1.0f);
        for (int i = 0; i < 360; i += 13)
        {
            //�Ѿ� ����
            GameObject temp = Instantiate(circleBullet);

            //2�ʸ��� ����
            Destroy(temp, 2f);

            //�Ѿ� ���� ��ġ�� (0,0) ��ǥ�� �Ѵ�.
            //temp.transform.position = Vector2.zero;
            temp.transform.position = gameObject.transform.position;

            //Z�� ���� ���ؾ� ȸ���� �̷�����Ƿ�, Z�� i�� �����Ѵ�.
            temp.transform.rotation = Quaternion.Euler(0, 0, i);
        }
        Destroy(gameObject);
        
    }
}
