using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elitemonstershot : MonoBehaviour
{
    GameObject bullet, pbullet; // �Ѿ� ������Ʈ
    Vector2 pos;

    int bulletpoint;

    public GameObject[] BulletPrefab;
    public GameObject[] PBulletPrefab;

    int turnbullet = 0;

    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        int BulletIndex = Random.Range(0, BulletPrefab.Length);
        bullet = BulletPrefab[BulletIndex];
        pbullet = PBulletPrefab[BulletIndex];

        StartCoroutine("Shot");
    }

    void Update()
    {
        timer += Time.deltaTime;
    }

    IEnumerator Shot()
    {

        GameObject temp = Instantiate(bullet);
        pos = gameObject.transform.position;
        temp.transform.position = pos; // ������ ���� ��ġ���� �Ѿ� ����
        turnbullet = 1;

        yield return new WaitForSeconds(0.3f); // 3�� �������� ����

        if (timer >= 10)
        {
            StopCoroutine("Shot");
            StopCoroutine("pShot");
            StartCoroutine("Shot2");
        }
        else
        {
            StartCoroutine("pShot"); //�ݺ��ؼ� �Լ� ����
        }

    }

    IEnumerator Shot2()
    {
        pos = this.gameObject.transform.position; //������ ���� ��ġ


        GameObject temp = Instantiate(bullet, pos, Quaternion.Euler(0, 0, 15f));
        GameObject temp2 = Instantiate(bullet, pos, Quaternion.Euler(0, 0, 0f));
        GameObject temp3 = Instantiate(bullet, pos, Quaternion.Euler(0, 0, -15f));
        turnbullet = 1;

        yield return new WaitForSeconds(0.5f); // 5�� �������� ����
        if (timer >= 20)
        {
            StopCoroutine("Shot2");
            StopCoroutine("pShot2");
            StartCoroutine("Shot");

            timer = 0;
        }
        else if(timer >= 10 || timer <20)
        {
            StartCoroutine("pShot2"); //�ݺ��ؼ� �Լ� ����
        }
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
