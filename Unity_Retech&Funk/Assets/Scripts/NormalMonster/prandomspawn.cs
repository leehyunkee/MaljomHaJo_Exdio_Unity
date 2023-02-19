using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prandomspawn : MonoBehaviour
{
    public GameObject monsterPrefab;
    private float spawnRangeX = 11f;
    private float spawnRangeY = 6f;
    private float spawnposZ = 20;


    //몬스터를 발생시킬 주기
    public float createTime;
    //몬스터의 최대 발생 개수
    public int maxMonster = 3;
    //게임 종료 여부 변수
    public bool isGameOver = false;
    float timer = 0;

    // Use this for initialization
    void Start()
    {
        createTime = 1;
        //몬스터 생성 코루틴 함수 호출
        StartCoroutine(this.CreateMonster());

    }

    void Update()
    {
        timer += Time.deltaTime;
    }


    // 화면에 너무 많지 않고 적당한 정도의 적까지만 소환돠게 해야함

    IEnumerator CreateMonster()
    {

        while (!isGameOver)
        {
            //현재 생성된 몬스터 개수 산출
            int monsterCount = (int)GameObject.FindGameObjectsWithTag("Enemy").Length;

            if (monsterCount < maxMonster && timer < 30)
            {
                //몬스터의 생성 주기 시간만큼 대기
                yield return new WaitForSeconds(createTime);

                //불규칙적인 위치 산출
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
