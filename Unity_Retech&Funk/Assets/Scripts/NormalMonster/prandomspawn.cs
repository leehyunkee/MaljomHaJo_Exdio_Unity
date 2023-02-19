using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prandomspawn : MonoBehaviour
{
    public GameObject monsterPrefab;
    private float spawnRangeX = 11f;
    private float spawnRangeY = 6f;
    private float spawnposZ = 20;


    //���͸� �߻���ų �ֱ�
    public float createTime;
    //������ �ִ� �߻� ����
    public int maxMonster = 3;
    //���� ���� ���� ����
    public bool isGameOver = false;
    float timer = 0;

    // Use this for initialization
    void Start()
    {
        createTime = 1;
        //���� ���� �ڷ�ƾ �Լ� ȣ��
        StartCoroutine(this.CreateMonster());

    }

    void Update()
    {
        timer += Time.deltaTime;
    }


    // ȭ�鿡 �ʹ� ���� �ʰ� ������ ������ �������� ��ȯ�°� �ؾ���

    IEnumerator CreateMonster()
    {

        while (!isGameOver)
        {
            //���� ������ ���� ���� ����
            int monsterCount = (int)GameObject.FindGameObjectsWithTag("Enemy").Length;

            if (monsterCount < maxMonster && timer < 30)
            {
                //������ ���� �ֱ� �ð���ŭ ���
                yield return new WaitForSeconds(createTime);

                //�ұ�Ģ���� ��ġ ����
                Vector3 spawnPos = new Vector3(Random.Range(0, spawnRangeX), Random.Range(-spawnRangeY, spawnRangeY), spawnposZ);
                Instantiate(monsterPrefab, spawnPos, monsterPrefab.transform.rotation);
            }
            else
            {
                yield return null;
            }
        }
    }
}
