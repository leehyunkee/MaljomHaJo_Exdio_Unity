using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    public GameObject bullet;
    bool bossSkill = false;
    public GameObject bigBullet;
    void Start()
    {
        StartCoroutine(BigBullet(4f));
    }
    Vector2 destination = new Vector2(11, 0);
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            bossSkill = true;
            //StartCoroutine(BossBack());
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            shot();
        }

        if(bossSkill)
        {
            transform.DetachChildren();
            transform.position = Vector2.MoveTowards(transform.position, destination, Time.deltaTime*2f);
            if (transform.position.x >= 11)
                bossSkill = false;
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(MoveUpDown());
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(Phase2());
        }
    }

    public void shot()
    {
        //360번 반복
        for (int i = 0; i < 360; i += 13)
        {
            //총알 생성
            GameObject temp = Instantiate(bullet);

            //2초마다 삭제
            Destroy(temp, 2f);

            //총알 생성 위치를 (0,0) 좌표로 한다.
            temp.transform.position = Vector2.zero;

            //Z에 값이 변해야 회전이 이루어지므로, Z에 i를 대입한다.
            temp.transform.rotation = Quaternion.Euler(0, 0, i);
        }
    }

    IEnumerator BossBack()
    {
        
        while(true)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, 1f);
            if(transform.position.x >10)
            {
                yield return null;
            }
        }
        
    }

    IEnumerator BigBullet(float time)
    {
        yield return new WaitForSeconds(time);
        GameObject bullet = Instantiate(bigBullet, transform.position, Quaternion.identity);
        StartCoroutine(BigBullet(time));
    }

    IEnumerator Phase2()
    {
        int a = Random.Range(2, 6);
        for (int i = 0; i < a; i++)
        {
           
            GameObject bullet = Instantiate(bigBullet, transform.position, Quaternion.identity);
            if (i == a - 1)
            {
                Debug.Log("color");
                bullet.GetComponent<SpriteRenderer>().color = new Color(132, 0, 0);
            }
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(Phase2());
    }

    IEnumerator MoveUpDown()
    {
        float speed = 0.1f;
        while(true)
        {
            // transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, 6), 1f);
            transform.Translate(0, speed, 0);
            if(transform.position.y>5)
            {
                speed *= -1;
            }
            if(transform.position.y<-5)
            {
                speed *= -1;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
