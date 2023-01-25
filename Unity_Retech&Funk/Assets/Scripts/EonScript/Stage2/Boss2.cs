using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    public GameObject bullet;
    bool bossSkill = false;
    public GameObject bigBullet;
    void Start()
    {
        StartCoroutine(BigBullet());
    }
    Vector2 destination = new Vector2(11, 0);
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            bossSkill = true;
            //StartCoroutine(BossBack());
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            shot();
        }

        if(bossSkill)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, Time.deltaTime*2f);
            if (transform.position.x >= 11)
                bossSkill = false;
        }
    }

    public void shot()
    {
        //360�� �ݺ�
        for (int i = 0; i < 360; i += 13)
        {
            //�Ѿ� ����
            GameObject temp = Instantiate(bullet);

            //2�ʸ��� ����
            Destroy(temp, 2f);

            //�Ѿ� ���� ��ġ�� (0,0) ��ǥ�� �Ѵ�.
            temp.transform.position = Vector2.zero;

            //Z�� ���� ���ؾ� ȸ���� �̷�����Ƿ�, Z�� i�� �����Ѵ�.
            temp.transform.rotation = Quaternion.Euler(0, 0, i);
        }
    }

    IEnumerator BossBack()
    {
        
        while(true)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, 1f);
            if(transform.position.x >10)
            {
                yield return null;
            }
        }
        
    }

    IEnumerator BigBullet()
    {
        yield return new WaitForSeconds(4f);
        GameObject bullet = Instantiate(bigBullet, transform.position, Quaternion.identity);
        StartCoroutine(BigBullet());
    }
}
