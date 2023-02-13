using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final_move : MonoBehaviour
{
    float UpMax = 2.0f; //좌로 이동가능한 (x)최대값

    float DownMax = -2.0f; //우로 이동가능한 (x)최대값

    float currentPositionY, currentPositionX; //현재 위치(x) 저장

    float directionX, directionY; //이동속도+방향

    float timer;

    int randommove;

    // Start is called before the first frame update

    void Start()
    {
        currentPositionX = this.gameObject.transform.localPosition.x;
        currentPositionY = this.gameObject.transform.localPosition.y;

        randommove = Random.Range(0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if(randommove == 0)
        {
            updownmove();
        }
        else if(randommove == 1)
        {
            RightLeftMove();
        }
        else if(randommove == 2)
        {
            DiagonalDownMove();
        }
        else if(randommove == 3)
        {
            DiagonalUpMove();
        }
        else
        {
            curvemove();
        }
    }

    void updownmove()
    {
        directionY = 3.0f;
        currentPositionY += Time.deltaTime * directionY;

        if (currentPositionY >= UpMax)

        {

            directionY *= -1;

        }

        //현재 위치(x)가 우로 이동가능한 (x)최대값보다 크거나 같다면

        //이동속도+방향에 -1을 곱해 반전을 해주고 현재위치를 우로 이동가능한 (x)최대값으로 설정

        else if (currentPositionY <= DownMax)

        {

            directionY *= -1;


        }

        //현재 위치(x)가 좌로 이동가능한 (x)최대값보다 크거나 같다면

        //이동속도+방향에 -1을 곱해 반전을 해주고 현재위치를 좌로 이동가능한 (x)최대값으로 설정

        this.gameObject.transform.localPosition = new Vector2(currentPositionX, currentPositionY);
        //"Stone"의 위치를 계산된 현재위치로 처리

        if (currentPositionX < -10 || currentPositionX > 10 || currentPositionY < -6 || currentPositionY > 6)
        {
            Destroy(gameObject);
        }
    }


    void RightLeftMove()
    {
        directionX = -6.0f;
        currentPositionX += Time.deltaTime * directionX;
        this.gameObject.transform.localPosition = new Vector2(currentPositionX, currentPositionY);

        if (currentPositionX < -10 || currentPositionX > 10 || currentPositionY < -6 || currentPositionY > 6)
        {
            Destroy(gameObject);
        }
    }

    void DiagonalDownMove()
    {
        directionX = -6.0f;
        directionY = -3.0f;

        currentPositionX += Time.deltaTime * directionX;
        currentPositionY += Time.deltaTime * directionY;
        this.gameObject.transform.localPosition = new Vector2(currentPositionX, currentPositionY);

        if (currentPositionX < -10 || currentPositionX > 10 || currentPositionY < -6 || currentPositionY > 6)
        {
            Destroy(gameObject);
        }
    }

    void DiagonalUpMove()
    {
        directionX = -6.0f;
        directionY = 3.0f;

        currentPositionX += Time.deltaTime * directionX;
        currentPositionY += Time.deltaTime * directionY;
        this.gameObject.transform.localPosition = new Vector2(currentPositionX, currentPositionY);

        if (currentPositionX < -10 || currentPositionX > 10 || currentPositionY < -6 || currentPositionY > 6)
        {
            Destroy(gameObject);
        }
    }

    void curvemove()
    {
        directionX = -6.0f;
        directionY = 3.0f;

        timer += Time.deltaTime;

        if (timer < 1.2)
        {
            currentPositionX += Time.deltaTime * directionX;
            currentPositionY += Time.deltaTime * directionY;
            this.gameObject.transform.localPosition = new Vector2(currentPositionX, currentPositionY);
        }
        else if (timer >= 1.2 || timer < 2.4)
        {

            currentPositionX += -Time.deltaTime * directionX;
            currentPositionY += Time.deltaTime * directionY;
            this.gameObject.transform.localPosition = new Vector2(currentPositionX, currentPositionY);
        }
        else
        {
            StartCoroutine(WaitForIt());
        }

        if (currentPositionX < -10 || currentPositionX > 10 || currentPositionY < -6 || currentPositionY > 6)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(2.0f);
    }
}
