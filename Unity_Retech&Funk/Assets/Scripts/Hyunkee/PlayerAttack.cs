using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private float curTime;
    public float coolTime = 0.5f;
    private float ComboCount = 3;
    public float UpdateComboCount = 3;
    private float comboCurTime;
    public float comboCoolTime;
    public Transform pos;
    public Vector2 boxSize;
    private void Update()
    {
        if (curTime <= 0 && comboCurTime <= 0) 
        {
            if (Input.GetMouseButtonDown(0))
            {
                //X Ű�� ������ ���������� ����
                ComboCount -= 1;
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
                foreach (Collider2D collider in collider2Ds)
                {
                    //������ ��ġ�� ���� ���� ���� �ִ� ���¿��� ���� �� �浹ó��
                    Debug.Log("������ �̳�");
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
}
