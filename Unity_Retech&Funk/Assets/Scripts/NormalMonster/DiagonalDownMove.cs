using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalDownMove : MonoBehaviour
{
    float currentPositionY, currentPositionX; //현재 위치(x) 저장

    float directionX = -6.0f; //이동속도+방향
    float directionY = -3.0f;



    void Start()

    {
        currentPositionX = this.gameObject.transform.localPosition.x;
        currentPositionY = this.gameObject.transform.localPosition.y;

    }

    // Update is called once per frame
    void Update()
    {
        currentPositionX += Time.deltaTime * directionX;
        currentPositionY += Time.deltaTime * directionY;
        this.gameObject.transform.localPosition = new Vector2(currentPositionX, currentPositionY);

        if (currentPositionX < -10)
        {
            Destroy(gameObject);
        }
    }
}
