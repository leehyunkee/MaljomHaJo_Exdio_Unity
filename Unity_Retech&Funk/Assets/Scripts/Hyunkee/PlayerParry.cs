/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParry : MonoBehaviour
{
    public GameObject bullet;
    public Transform pos;
    public float cooltime;
    private float curtime;
    PlayerAttack playerAttack;
    private void Awake()
    {
        playerAttack = GameObject.Find("Player").GetComponent<PlayerAttack>();
        //특정 스크립트를 불러오기 위한 코드
    }

    private void Update()
    {
        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);
        if (curtime <= 0)
        {
            //마우스 왼쪽 버튼 누를 때
            if (Input.GetMouseButtonDown(0) && playerAttack.isParry == true)//코드 내의 변수를 .을 이용해 가져옴
            {
                Instantiate(bullet, parrypos.position, transform.rotation);
                playerAttack.IsParryFalse();//스크립트 내의 함수 가져오기
            }
            curtime = cooltime;
        }
        curtime -= Time.deltaTime;

    }
}*/