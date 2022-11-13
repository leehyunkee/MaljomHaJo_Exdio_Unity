using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeShot : MonoBehaviour {

    public GameObject bullet; // 총알 오브젝트
    Vector2 pos;

    void Start()
    {
        StartCoroutine("Shot2"); //반복해서 함수 수행
        pos = this.gameObject.transform.localPosition; //몬스터의 현재 위치
    }

    IEnumerator Shot2()
    {
        //360번 반복
        for (int i = -15; i < 15; i += 13)
        {
            //총알 생성
            GameObject temp = Instantiate(bullet);

            //1초마다 삭제
            Destroy(temp, 1.0f);

            // 몬스터의 현재 위치에서 총알 복제
            temp.transform.position = pos;

            //Z에 값이 변해야 회전이 이루어지므로, Z에 i를 대입
            temp.transform.rotation = Quaternion.Euler(0, 0, i);

            yield return new WaitForSeconds(0.5f); // 5초 간격으로 복제
            StartCoroutine("Shot2"); //반복해서 함수 수행
        }
    }
}
