using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLeftMove : MonoBehaviour
{
    float currentPositionY, currentPositionX; //현재 위치(x) 저장

    float direction = -6.0f; //이동속도+방향




    void Start()

    {
        currentPositionX = this.gameObject.transform.localPosition.x;
        currentPositionY = this.gameObject.transform.localPosition.y;

    }

    // Update is called once per frame
    void Update()
    {
         currentPositionX += Time.deltaTime * direction;
            this.gameObject.transform.localPosition = new Vector2(currentPositionX, currentPositionY);

    }
}
