using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //충돌판정으로 데미지를 받는 스크립트
    public bool isHurt = false;
    public SpriteRenderer sr;
    Color halfA = new Color(1, 1, 1, 0.5f);
    Color fullA = new Color(1, 1, 1, 1);


    
    public int Hp = 3;
    public int nowHp ;


    void Start()
    {
        nowHp = Hp;

    }
    

    public Animator anim;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isHurt == false && collision.gameObject.tag == ("Enemy") || isHurt == false && collision.gameObject.tag == ("parry")) 
        {
            //collision이 충돌체의 정보를 다 갖고있음. => 부딫힌 gameobject 자체를 바로 없앨 수 있음

            Destroy(collision.gameObject);
            Debug.Log("탄막충돌");
            Hurt();
            
        }
        else if (isHurt == false && collision.gameObject.tag == ("sdEnemy") || isHurt == false && collision.gameObject.tag == ("parry"))
        {
            //collision이 충돌체의 정보를 다 갖고있음. => 부딫힌 gameobject 자체를 바로 없앨 수 있음

            
            Debug.Log("잡몹충돌");
            Hurt();

        }

    }
    public void Hurt()
    {


        if (!isHurt)
        {
            isHurt = true;
            nowHp -= 1;
            Debug.Log("데미지 들어감");
            if (nowHp <= 0)
            {
                Invoke("freeze", 1);
            }
            else
            {
                StartCoroutine(HurtRoutine());
                StartCoroutine(alphablink());
            }
            
            
        }
    }
    IEnumerator HurtRoutine()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("쉬어가기");
        isHurt = false;
    }
    IEnumerator alphablink()
    {
        while (isHurt)
        {
            yield return new WaitForSeconds(0.1f);
            sr.color = halfA;
            yield return new WaitForSeconds(0.1f);
            sr.color = fullA;
        }
    }
    void freeze()
    {
        Time.timeScale = 0;
    }
}
