using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBullet_ : Bullet
{

    public GameObject circleBullet;
    protected override void Timer()
    {
        base.Timer();
        StartCoroutine(ReadyCircle());

    }

    IEnumerator ReadyCircle()
    {
        Debug.Log("hi");
        yield return new WaitForSeconds(1.0f);
        for (int i = 0; i < 360; i += 13)
        {
            //총알 생성
            GameObject temp = Instantiate(circleBullet);

            //2초마다 삭제
            Destroy(temp, 2f);

            //총알 생성 위치를 (0,0) 좌표로 한다.
            //temp.transform.position = Vector2.zero;
            temp.transform.position = gameObject.transform.position;

            //Z에 값이 변해야 회전이 이루어지므로, Z에 i를 대입한다.
            temp.transform.rotation = Quaternion.Euler(0, 0, i);
        }
        Destroy(gameObject);
        
    }
}
