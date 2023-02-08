using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletshot : MonoBehaviour
{

    public GameObject bullet1; // 총알 오브젝트
    public GameObject bullet2;
    Vector2 pos;

    void Start()
    {
        StartCoroutine("Shot"); //반복해서 함수 수행
        StartCoroutine("Shot2");
        //pos = this.gameObject.transform.localPosition; //몬스터의 현재 위치
    }


    IEnumerator Shot()
    {

        GameObject temp = Instantiate(bullet1); // 총알 복제
        pos = gameObject.transform.position;
        temp.transform.position = pos; // 몬스터의 현재 위치에서 총알 복제
        yield return new WaitForSecondsRealtime(0.3f); // 3초 간격으로 복제
        StartCoroutine("Shot"); //반복해서 함수 수행

    }

    IEnumerator Shot2()
    {

        GameObject temp = Instantiate(bullet2); // 총알 복제
        pos = gameObject.transform.position;
        temp.transform.position = pos; // 몬스터의 현재 위치에서 총알 복제
        yield return new WaitForSecondsRealtime(1.0f); // 3초 간격으로 복제
        StartCoroutine("Shot2"); //반복해서 함수 수행

    }
}