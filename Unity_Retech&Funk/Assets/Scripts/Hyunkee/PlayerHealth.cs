using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
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
    public GameObject obj;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isHurt == false && collision.gameObject.tag == ("Enemy"))
        {
            //collision�� �浹ü�� ������ �� ��������. => �΋H�� gameobject ��ü�� �ٷ� ���� �� ����

            Destroy(collision.gameObject);
            Debug.Log("�ƾ�");
            Hurt();
            
        }
        else if (isHurt == false && collision.gameObject.tag == ("sdEnemy"))
        {
            //collision�� �浹ü�� ������ �� ��������. => �΋H�� gameobject ��ü�� �ٷ� ���� �� ����

            
            Debug.Log("�����ƾ�");
            Hurt();

        }

    }
    public void Hurt()
    {


        if (!isHurt)
        {
            isHurt = true;
            nowHp -= 1;
            Debug.Log("������ ��");
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
        Debug.Log("�����");
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
