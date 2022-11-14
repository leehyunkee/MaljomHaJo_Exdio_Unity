using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeShot : MonoBehaviour {

    public GameObject bullet; // 총알 오브젝트
    Vector2 pos;

    void Start()
    {
        StartCoroutine("Shot2"); //반복해서 함수 수행
        pos = this.gameObject.transform.position; //몬스터의 현재 위치
    }

    IEnumerator Shot2()
    {

            GameObject temp = Instantiate(bullet,pos, Quaternion.Euler(0, 0, 15f));
            GameObject temp2 = Instantiate(bullet, pos, Quaternion.Euler(0, 0, 0f));
            GameObject temp3 = Instantiate(bullet, pos, Quaternion.Euler(0, 0, -15f));


        yield return new WaitForSeconds(0.5f); // 5초 간격으로 복제
            StartCoroutine("Shot2"); //반복해서 함수 수행
    }
}
