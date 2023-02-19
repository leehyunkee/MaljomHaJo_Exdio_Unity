using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecendShot : MonoBehaviour
{
    GameObject bullet; // 총알 오브젝트
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
    }


    IEnumerator Shot()
    {

        GameObject temp = Instantiate(bullet); // 총알 복제
        pos = gameObject.transform.position;
        temp.transform.position = pos; // 몬스터의 현재 위치에서 총알 복제
        yield return new WaitForSeconds(0.3f); // 3초 간격으로 복제
        StartCoroutine("Shot"); //반복해서 함수 수행

    }

    IEnumerator Shot2()
    {
        pos = this.gameObject.transform.position; //몬스터의 현재 위치

        GameObject temp = Instantiate(bullet, pos, Quaternion.Euler(0, 0, 15f));
        GameObject temp2 = Instantiate(bullet, pos, Quaternion.Euler(0, 0, 0f));
        GameObject temp3 = Instantiate(bullet, pos, Quaternion.Euler(0, 0, -15f));


        yield return new WaitForSeconds(0.5f); // 5초 간격으로 복제
        StartCoroutine("Shot2"); //반복해서 함수 수행
    }

    IEnumerator Shot3()
    {

        while (true)
        {

            for (int fireAngle = startAngle; fireAngle < endAngle; fireAngle += angleInterval)
            {
                GameObject temp = Instantiate(bullet);
                temp.transform.position = pos;
                Vector2 direction = new Vector2(Mathf.Cos(fireAngle * Mathf.Rad2Deg), Mathf.Sin(fireAngle * Mathf.Rad2Deg));

                temp.transform.right = direction;
                temp.transform.position = transform.position;
            }

            yield return new WaitForSeconds(2.0f);
            StartCoroutine("Shot3"); //반복해서 함수 수행

        }

    }
}
