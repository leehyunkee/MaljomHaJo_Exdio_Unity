using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstShot : MonoBehaviour
{
    GameObject bullet; // �Ѿ� ������Ʈ
    Vector2 pos;

    int randombullet;

    public GameObject[] BulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        int BulletIndex = Random.Range(0, BulletPrefab.Length);
        bullet = BulletPrefab[BulletIndex];

        randombullet = Random.Range(0, 2);

        if (randombullet == 0)
        {
            StartCoroutine("Shot");
        }
        else if (randombullet == 1)
        {
            StartCoroutine("Shot2");
        }
    }


    IEnumerator Shot()
    {

        GameObject temp = Instantiate(bullet); // �Ѿ� ����
        pos = gameObject.transform.position;
        temp.transform.position = pos; // ������ ���� ��ġ���� �Ѿ� ����
        yield return new WaitForSeconds(0.7f); // 0.7�� �������� ����
        StartCoroutine("Shot"); //�ݺ��ؼ� �Լ� ����

    }

    IEnumerator Shot2()
    {
        pos = this.gameObject.transform.position; //������ ���� ��ġ

        GameObject temp = Instantiate(bullet, pos, Quaternion.Euler(0, 0, 15f));
        GameObject temp2 = Instantiate(bullet, pos, Quaternion.Euler(0, 0, 0f));
        GameObject temp3 = Instantiate(bullet, pos, Quaternion.Euler(0, 0, -15f));


        yield return new WaitForSeconds(1f); // 1�� �������� ����
        StartCoroutine("Shot2"); //�ݺ��ؼ� �Լ� ����
    }
}
