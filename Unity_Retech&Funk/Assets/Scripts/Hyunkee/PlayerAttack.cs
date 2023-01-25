using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject Playerbullet;
    public Transform pos;

}
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public GameObject bullet;
    public Transform parrypos;


    private float curTime;
    public float coolTime = 0.5f;
    private float ComboCount = 3;
    public float UpdateComboCount = 3;
    private float comboCurTime;
    public float comboCoolTime;
    public Transform pos;
    public Vector2 boxSize;
    public bool isParry = false;
    private void Update()
    {



    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (curTime <= 0 && comboCurTime <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (collision.gameObject.tag == "parry")
                {
                    IsParryTrue();
                }
                //마우스 왼쪽 키를 누르면 근접공격이 나감
                ComboCount -= 1;
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
                foreach (Collider2D collider in collider2Ds)
                {
                    Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                    float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(0, 0, z);
                    if (comboCurTime <= 0)
                    {
                        //마우스 왼쪽 버튼 누를 때
                        if (isParry == true)
                        {
                            Instantiate(bullet, parrypos.position, transform.rotation);
                            IsParryFalse();
                        }
                        else
                        {

                            //지정한 위치의 범위 내에 적이 있는 상태에서 공격 시 충돌처리
                            Debug.Log("에라이 이놈");
                        }
                    }
                    comboCurTime -= Time.deltaTime;


                }
                curTime = coolTime;
            }
            if (ComboCount <= 0)
            {
                comboCurTime = comboCoolTime;
                ComboCount = UpdateComboCount;
            }
        }
        else
        {
            curTime -= Time.deltaTime;
            comboCurTime -= Time.deltaTime;
        }

    }
    private void OnDrawGizmos()
    {
        //범위 사이즈 확인을 위해 넣어둔 코드
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
    public void IsParryTrue()
    {
        isParry = true;
    }
    public void IsParryFalse()
    {
        isParry = false;
    }
}

*/