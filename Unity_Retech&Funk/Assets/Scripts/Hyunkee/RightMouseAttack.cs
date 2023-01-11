using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMouseAttack : MonoBehaviour
{
    private float curTime;
    public float coolTime = 0.5f;
    public Transform pos;
    public Vector2 boxSize;

    private float ComboCount = 3;
    public float UpdateComboCount = 3;
    private float comboCurTime;
    public float comboCoolTime;


    private void Update()
    {
        if (curTime <= 0 && comboCurTime <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ComboCount-=1;
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
                foreach (Collider2D collider in collider2Ds)
                {
                    Debug.Log(collider.tag);
                    
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
}
