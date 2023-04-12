using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMouseAttack : MonoBehaviour
{
    private float curTime;
    public float coolTime = 0.3f;
    public Transform pos;
    public Vector2 boxSize;

    public float ComboCount = 0;
    public float UpdateComboCount = 3;
    private float comboCurTime;
    public float comboCoolTime;

    private PlayerParry parrying;
    public Animator animator;

    public GameObject particles1;
    public GameObject particles2;

    public Boss_1 boss;
    private void Awake()
    {
        parrying = GameObject.Find("ParryPos").GetComponent<PlayerParry>();
        //Ư�� ��ũ��Ʈ�� �ҷ����� ���� �ڵ�
    }

    //public bool parryBullet = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        particles1.SetActive(false);
        particles2.SetActive(false);

    }
    private void Update()
    {
        if (curTime <= 0 && comboCurTime <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ComboCount+=1;
                
                if(ComboCount == 1)
                {
                    particles2.SetActive(false);
                    particles2.SetActive(true);
                    particles1.SetActive(false);
                }
                else if (ComboCount == 2)
                {
                    particles1.SetActive(true);
                    particles2.SetActive(false);
                }
                else if (ComboCount == 3)
                {
                    particles2.SetActive(true);
                    particles1.SetActive(false);
                }
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
                animator.SetFloat("Blend",ComboCount);
                animator.SetTrigger("Atk");
                foreach (Collider2D collider in collider2Ds)
                {
                    Debug.Log(collider.gameObject.tag);
                    if (collider.gameObject.tag == "Enemy")     //�ڽ� ������ ������ ��ü�� tag == Enemy(���)�� ��� 
                    {
                        Destroy(collider.gameObject);
                        Debug.Log("������ ������");
                    }
                    else if (collider.gameObject.tag == "parry")//�ڽ� ������ ������ ��ü�� tag == parry(�и� ������ ź��)�� ���
                    {
                        Debug.Log("�и� ����");
                        Destroy(collider.gameObject);           //ź�� �Ҹ�
                        //isParryTrue();
                        parrying.parryTrue();
                    }
                    else if(collider.gameObject.tag == "Boss")
                    {
                        boss.bossHealth--;
                        StartCoroutine(boss.PhaseCheck());
                        Debug.Log("Boss");
                    }
                    else
                    {
                    }
                    
                }
                curTime = coolTime;
            }
            
            
            if (ComboCount >= UpdateComboCount)
            {
                comboCurTime = comboCoolTime;
                ComboCount = 0;
            }
        }
        else
        {
            curTime -= Time.deltaTime;
            comboCurTime -= Time.deltaTime;
        }
    }

    /*private void particleTrue()
    {
        particles.SetActive(true);
    }
    private void particleFalse()
    {
        particles.SetActive(false);
    }*/
    //private void OnDrawGizmos()
    //{
    //    //���� ������ Ȯ���� ���� �־�� �ڵ�
    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawWireCube(pos.position, boxSize);
    //}
    /*public void isParryTrue()
    {
        parryBullet = true;
    }
    public void isParryFalse()
    {
        parryBullet = false;
    }*/
}
