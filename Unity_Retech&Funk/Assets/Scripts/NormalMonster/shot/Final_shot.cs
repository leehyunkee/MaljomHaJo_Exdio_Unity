using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final_shot : MonoBehaviour
{
    GameObject bullet; // �Ѿ� ������Ʈ
    Vector2 pos;

    public int angleInterval = 10;
    public int startAngle = 0;
    public int endAngle = 360;

    int randombullet;

    public GameObject[] BulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        int BulletIndex = Random.Range(0, BulletPrefab.Length);
        bullet = BulletPrefab[BulletIndex];

        randombullet = Random.Range(0, 5);

        if (randombullet == 0)
        {
            StartCoroutine("Shot");
        }
        else if (randombullet == 1)
        {
            StartCoroutine("Shot2");
        }
        else
        {
            StartCoroutine("Shot3");
        }

        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    Vector3 spawnPos = new Vector3(Random.Range(0, spawnRangeX), Random.Range(-spawnRangeY, spawnRangeY), spawnposZ);
        //    int monsterIndex = Random.Range(0, monsterPrefab.Length);
        //    Instantiate(monsterPrefab[monsterIndex], spawnPos, monsterPrefab[monsterIndex].transform.rotation);
        //}
    }


    IEnumerator Shot()
    {

        GameObject temp = Instantiate(bullet); // �Ѿ� ����
        pos = gameObject.transform.position;
        temp.transform.position = pos; // ������ ���� ��ġ���� �Ѿ� ����
        yield return new WaitForSeconds(0.3f); // 3�� �������� ����
        StartCoroutine("Shot"); //�ݺ��ؼ� �Լ� ����

    }

    IEnumerator Shot2()
    {
        pos = this.gameObject.transform.position; //������ ���� ��ġ

        GameObject temp = Instantiate(bullet, pos, Quaternion.Euler(0, 0, 15f));
        GameObject temp2 = Instantiate(bullet, pos, Quaternion.Euler(0, 0, 0f));
        GameObject temp3 = Instantiate(bullet, pos, Quaternion.Euler(0, 0, -15f));


        yield return new WaitForSeconds(0.5f); // 5�� �������� ����
        StartCoroutine("Shot2"); //�ݺ��ؼ� �Լ� ����
    }

    IEnumerator Shot3()
    {

        while (true)
        {

            for (int fireAngle = startAngle; fireAngle < endAngle; fireAngle += angleInterval)
            {
                GameObject temp = Instantiate(bullet);
                temp.transform.position = pos;
                Vector2 direction = new Vector2(Mathf.Cos(fireAngle * Mathf.Rad2Deg), Mathf.Sin(fireAngle * Mathf.Rad2Deg)); //�ӽ�(������ ���׶��� ����)

                temp.transform.right = direction;
                temp.transform.position = transform.position;
            }

            yield return new WaitForSeconds(2.0f);
            StartCoroutine("Shot3"); //�ݺ��ؼ� �Լ� ����

        }

    }
}
