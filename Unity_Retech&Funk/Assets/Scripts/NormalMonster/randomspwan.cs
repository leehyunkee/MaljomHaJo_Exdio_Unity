using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomspwan : MonoBehaviour
{

    public GameObject[] monsterPrefab;
    private float spawnRangeX = 11f;
    private float spawnRangeY = 6f;


    //몬스터를 발생시킬 주기
    public float createTime;
    //몬스터의 최대 발생 개수
    public int maxMonster = 10;
    //게임 종료 여부 변수
    public bool isGameOver = false;

    // Use this for initialization
    void Start()
    {
        createTime = 1;

            //몬스터 생성 코루틴 함수 호출
        StartCoroutine(this.CreateMonster());

    }


// 화면에 너무 많지 않고 적당한 정도의 적까지만 소환돠게 해야함

    IEnumerator CreateMonster()
    {
    //게임 종료 시까지 무한 루프
        while (!isGameOver)
     {
        //현재 생성된 몬스터 개수 산출
            int monsterCount = (int)GameObject.FindGameObjectsWithTag("Enemy").Length;

         if (monsterCount < maxMonster)
          {
                //몬스터의 생성 주기 시간만큼 대기
                yield return new WaitForSeconds(createTime);

                //불규칙적인 위치 산출
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

