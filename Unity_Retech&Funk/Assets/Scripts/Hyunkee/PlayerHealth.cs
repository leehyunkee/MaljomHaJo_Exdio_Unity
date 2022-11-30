using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public bool isHurt;
    SpriteRenderer sr;
    Color halfA = new Color(1, 1, 1, 0.5f);
    Color fullA = new Color(1, 1, 1, 1);


    
    public int Hp = 3;
    public int nowHp ;


    void Start()
    {
        nowHp = Hp;
    }
    public void TakeDamage(int damage)
    {
        nowHp -= damage;
        Debug.Log("Damage");

    }
    
    public void Hurt()
    {


        if (!isHurt)
        {
            isHurt = true;
            nowHp -= 1;
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
        yield return new WaitForSeconds(5f);
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
