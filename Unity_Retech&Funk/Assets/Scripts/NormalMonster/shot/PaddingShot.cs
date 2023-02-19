using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddingShot : MonoBehaviour
{
    GameObject bullet, pbullet; // �Ѿ� ������Ʈ
    Vector2 pos;

    int randombullet;

    public GameObject[] BulletPrefab;
    public GameObject[] PBulletPrefab;

    int turnbullet = 0;
    // Start is called before the first frame update
    void Start()
    {
        int BulletIndex = Random.Range(0, BulletPrefab.Length);
        bullet = BulletPrefab[BulletIndex];
        pbullet = PBulletPrefab[BulletIndex];

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

        GameObject temp = Instantiate(bullet);
        pos = gameObject.transform.position;
        temp.transform.position = pos; // ������ ���� ��ġ���� �Ѿ� ����
        turnbullet = 1;

        yield return new WaitForSeconds(0.3f); // 3�� �������� ����

        StartCoroutine("pShot"); //�ݺ��ؼ� �Լ� ����

    }

    IEnumerator Shot2()
    {
        pos = this.gameObject.transform.position; //������ ���� ��ġ


        GameObject temp = Instantiate(bullet, pos, Quaternion.Euler(0, 0, 15f));
        GameObject temp2 = Instantiate(bullet, pos, Quaternion.Euler(0, 0, 0f));
        GameObject temp3 = Instantiate(bullet, pos, Quaternion.Euler(0, 0, -15f));
        turnbullet = 1;

        yield return new WaitForSeconds(0.5f); // 5�� �������� ����
        StartCoroutine("pShot2"); //�ݺ��ؼ� �Լ� ����
    }

    IEnumerator pShot()
    {

        GameObject temp = Instantiate(pbullet);
        pos = gameObject.transform.position;
        temp.transform.position = pos; // ������ ���� ��ġ���� �Ѿ� ����
        turnbullet = 1;

        yield return new WaitForSeconds(0.3f); // 3�� �������� ����

        StartCoroutine("Shot"); //�ݺ��ؼ� �Լ� ����
    }

    IEnumerator pShot2()
    {
        pos = this.gameObject.transform.position; //������ ���� ��ġ


        GameObject temp = Instantiate(pbullet, pos, Quaternion.Euler(0, 0, 15f));
        GameObject temp2 = Instantiate(pbullet, pos, Quaternion.Euler(0, 0, 0f));
        GameObject temp3 = Instantiate(pbullet, pos, Quaternion.Euler(0, 0, -15f));
        turnbullet = 1;

        yield return new WaitForSeconds(0.5f); // 5�� �������� ����

        StartCoroutine("Shot2"); //�ݺ��ؼ� �Լ� ����
    }
}
