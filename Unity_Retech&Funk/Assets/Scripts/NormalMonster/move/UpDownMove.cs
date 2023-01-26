using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownMove : MonoBehaviour
{
    float UpMax = 3.5f; //좌로 이동가능한 (x)최대값

    float DownMax = -3.5f; //우로 이동가능한 (x)최대값

    float currentPositionY, currentPositionX; //현재 위치(x) 저장

    float direction = 3.0f; //이동속도+방향




    void Start()

    {
        currentPositionX = this.gameObject.transform.localPosition.x;
        currentPositionY = this.gameObject.transform.localPosition.y;

    }




    void Update()

    {

        currentPositionY += Time.deltaTime * direction;

        if (currentPositionY >= UpMax)

        {

            direction *= -1;

            currentPositionY = UpMax;

        }

        //현재 위치(x)가 우로 이동가능한 (x)최대값보다 크거나 같다면

        //이동속도+방향에 -1을 곱해 반전을 해주고 현재위치를 우로 이동가능한 (x)최대값으로 설정

        else if (currentPositionY <= DownMax)

        {

            direction *= -1;

            currentPositionY = DownMax;

        }

        //현재 위치(x)가 좌로 이동가능한 (x)최대값보다 크거나 같다면

        //이동속도+방향에 -1을 곱해 반전을 해주고 현재위치를 좌로 이동가능한 (x)최대값으로 설정

        this.gameObject.transform.localPosition = new Vector2(currentPositionX, currentPositionY);
        //"Stone"의 위치를 계산된 현재위치로 처리

    }
}
