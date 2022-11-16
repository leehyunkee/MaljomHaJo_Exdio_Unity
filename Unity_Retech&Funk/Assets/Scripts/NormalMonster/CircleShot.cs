using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleShot : MonoBehaviour
{

    public GameObject bullet; // 총알 오브젝트
    Vector2 pos;

    public int angleInterval = 10;
    public int startAngle = 0;
    public int endAngle = 360;

    void Start()
    {
        StartCoroutine("Shot"); //반복해서 함수 수행
        pos = gameObject.transform.position;
        //pos = this.gameObject.transform.localPosition; //몬스터의 현재 위치
    }


    IEnumerator Shot()
    {

        while (true)
        {

            for (int fireAngle = startAngle; fireAngle < endAngle; fireAngle += angleInterval)
            {
                GameObject temp = Instantiate(bullet);
                temp.transform.position = pos;
                Vector2 direction = new Vector2(Mathf.Cos(fireAngle * Mathf.Rad2Deg), Mathf.Sin(fireAngle * Mathf.Rad2Deg)); //임시(완전히 동그랗지 않음)

                temp.transform.right = direction;
                temp.transform.position = transform.position;
            }

            yield return new WaitForSeconds(2.0f); 
            StartCoroutine("Shot"); //반복해서 함수 수행

        }

    }


}
