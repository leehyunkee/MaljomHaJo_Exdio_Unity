using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterHP : MonoBehaviour
{
    float currentPositionY, currentPositionX; //현재 위치(x) 저장
    int hp = 100;
    int deadcount = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        currentPositionX = this.gameObject.transform.localPosition.x;
        currentPositionY = this.gameObject.transform.localPosition.y;

        if (currentPositionX < -14f || currentPositionX > 14f || currentPositionY < -8f || currentPositionY > 8f)
        {
            Dead();
        }

        if(hp <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        deadcount += 1;
        Destroy(gameObject);
    }
}
