using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveShot : MonoBehaviour
{


    public GameObject bullet; // 총알 오브젝트
    Vector2 pos;

    public AnimationCurve curve;
    Vector2 startPos;
    Vector2 targetPos;
    float timer = 0.0f;

    void Start()
    {
        StartCoroutine("Shot"); //반복해서 함수 수행
        pos = gameObject.transform.position;
        //pos = this.gameObject.transform.localPosition; //몬스터의 현재 위치
        targetPos = startPos + new Vector2(100, 0);
    }


    IEnumerator Shot()
    {

        while (true)
        {

            timer += Time.deltaTime;
            GameObject temp = Instantiate(bullet);
            //temp.transform.position = pos;

            temp.transform.position = Vector3.Lerp(pos, targetPos, curve.Evaluate(timer));

            yield return new WaitForSeconds(2.0f);
            StartCoroutine("Shot"); //반복해서 함수 수행

        }

    }
}
