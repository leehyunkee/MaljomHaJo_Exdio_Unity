using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddingShot : MonoBehaviour
{
    GameObject bullet, pbullet; // 총알 오브젝트
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
        temp.transform.position = pos; // 몬스터의 현재 위치에서 총알 복제
        turnbullet = 1;

        yield return new WaitForSeconds(0.3f); // 3초 간격으로 복제

        StartCoroutine("pShot"); //반복해서 함수 수행

    }

    IEnumerator Shot2()
    {
        pos = this.gameObject.transform.position; //몬스터의 현재 위치


        GameObject temp = Instantiate(bullet, pos, Quaternion.Euler(0, 0, 15f));
        GameObject temp2 = Instantiate(bullet, pos, Quaternion.Euler(0, 0, 0f));
        GameObject temp3 = Instantiate(bullet, pos, Quaternion.Euler(0, 0, -15f));
        turnbullet = 1;

        yield return new WaitForSeconds(0.5f); // 5초 간격으로 복제
        StartCoroutine("pShot2"); //반복해서 함수 수행
    }

    IEnumerator pShot()
    {

        GameObject temp = Instantiate(pbullet);
        pos = gameObject.transform.position;
        temp.transform.position = pos; // 몬스터의 현재 위치에서 총알 복제
        turnbullet = 1;

        yield return new WaitForSeconds(0.3f); // 3초 간격으로 복제

        StartCoroutine("Shot"); //반복해서 함수 수행
    }

    IEnumerator pShot2()
    {
        pos = this.gameObject.transform.position; //몬스터의 현재 위치


        GameObject temp = Instantiate(pbullet, pos, Quaternion.Euler(0, 0, 15f));
        GameObject temp2 = Instantiate(pbullet, pos, Quaternion.Euler(0, 0, 0f));
        GameObject temp3 = Instantiate(pbullet, pos, Quaternion.Euler(0, 0, -15f));
        turnbullet = 1;

        yield return new WaitForSeconds(0.5f); // 5초 간격으로 복제

        StartCoroutine("Shot2"); //반복해서 함수 수행
    }
}
