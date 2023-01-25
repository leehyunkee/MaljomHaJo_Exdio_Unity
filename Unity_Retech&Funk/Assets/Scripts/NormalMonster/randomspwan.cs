using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomspwan : MonoBehaviour
{

    public GameObject[] monsterPrefab;
    private float spawnRangeX = 11f;
    private float spawnRangeY = 6f;


    //���͸� �߻���ų �ֱ�
    public float createTime;
    //������ �ִ� �߻� ����
    public int maxMonster = 10;
    //���� ���� ���� ����
    public bool isGameOver = false;

    // Use this for initialization
    void Start()
    {


            //���� ���� �ڷ�ƾ �Լ� ȣ��
       StartCoroutine(this.CreateMonster());

    }


// ȭ�鿡 �ʹ� ���� �ʰ� ������ ������ �������� ��ȯ�°� �ؾ���

    IEnumerator CreateMonster()
    {
    //���� ���� �ñ��� ���� ����
        while (!isGameOver)
     {
        //���� ������ ���� ���� ����
            int monsterCount = (int)GameObject.FindGameObjectsWithTag("Enemy").Length;

         if (monsterCount < maxMonster)
          {
                //������ ���� �ֱ� �ð���ŭ ���
                yield return new WaitForSeconds(createTime);

                //�ұ�Ģ���� ��ġ ����
                Vector2 spawnPos = new Vector2(Random.Range(0, spawnRangeX), Random.Range(-spawnRangeY, spawnRangeY));
                int monsterIndex = Random.Range(0, monsterPrefab.Length);
                Instantiate(monsterPrefab[monsterIndex], spawnPos, monsterPrefab[monsterIndex].transform.rotation);
            }
         else
          {
               yield return null;
          }
     }
    }
}

