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
                //���콺 ���� Ű�� ������ ���������� ����
                ComboCount -= 1;
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
                foreach (Collider2D collider in collider2Ds)
                {
                    Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                    float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(0, 0, z);
                    if (comboCurTime <= 0)
                    {
                        //���콺 ���� ��ư ���� ��
                        if (isParry == true)
                        {
                            Instantiate(bullet, parrypos.position, transform.rotation);
                            IsParryFalse();
                        }
                        else
                        {

                            //������ ��ġ�� ���� ���� ���� �ִ� ���¿��� ���� �� �浹ó��
                            Debug.Log("������ �̳�");
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
        //���� ������ Ȯ���� ���� �־�� �ڵ�
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