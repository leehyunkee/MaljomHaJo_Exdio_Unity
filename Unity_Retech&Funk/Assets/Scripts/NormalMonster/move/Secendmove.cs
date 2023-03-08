using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secendmove : MonoBehaviour
{
    float UpMax = 3.0f; //좌로 이동가능한 (x)최대값

    float DownMax = -3.0f; //우로 이동가능한 (x)최대값

    float currentPositionY, currentPositionX; //현재 위치(x) 저장

    float directionX, directionY; //이동속도+방향

    float timer;

    int randommove;

    bool turnSwitch = true;

    // Start is called before the first frame update

    void Start()
    {
        currentPositionX = this.gameObject.transform.localPosition.x;
        currentPositionY = this.gameObject.transform.localPosition.y;

        randommove = Random.Range(0, 6);
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
        else if (randommove == 4)
        {
            curvemove();
        }
        else
        {
            this.gameObject.transform.localPosition = new Vector2(currentPositionX, currentPositionY);
        }


        if (currentPositionX < -10 || currentPositionX > 10 || currentPositionY < -6 || currentPositionY > 6)
        {
            Destroy(gameObject);
        }
    }

    void updownmove()
    {
        directionY = 1.0f;

        float currentPositionY = transform.position.y;

        if (currentPositionY >= UpMax)
        {
            turnSwitch = false;
        }
        else if (currentPositionY <= DownMax)
        {
            turnSwitch = true;
        }

        if (turnSwitch)
        {
            transform.position = transform.position + new Vector3(0, 1, 0) * directionY * Time.deltaTime;
        }
        else
        {
            transform.position = transform.position + new Vector3(0, -1, 0) * directionY * Time.deltaTime;
        }

    }


    void RightLeftMove()
    {
        directionX = -2.0f;
        currentPositionX += Time.deltaTime * directionX;
        this.gameObject.transform.localPosition = new Vector2(currentPositionX, currentPositionY);
    }

    void DiagonalDownMove()
    {
        directionX = -2.0f;
        directionY = -1.0f;

        currentPositionX += Time.deltaTime * directionX;
        currentPositionY += Time.deltaTime * directionY;
        this.gameObject.transform.localPosition = new Vector2(currentPositionX, currentPositionY);
    }

    void DiagonalUpMove()
    {
        directionX = -2.0f;
        directionY = 1.0f;

        currentPositionX += Time.deltaTime * directionX;
        currentPositionY += Time.deltaTime * directionY;
        this.gameObject.transform.localPosition = new Vector2(currentPositionX, currentPositionY);
    }

    void curvemove()
    {
        directionX = -2.0f;
        directionY = 1.0f;

        timer += Time.deltaTime;

        if (timer < 1.2f)
        {
            currentPositionX += Time.deltaTime * directionX;
            currentPositionY += Time.deltaTime * directionY;
            this.gameObject.transform.localPosition = new Vector2(currentPositionX, currentPositionY);
        }
        else if (timer >= 1.2f || timer < 2.4f)
        {

            currentPositionX += -Time.deltaTime * directionX;
            currentPositionY += -Time.deltaTime * directionY;
            this.gameObject.transform.localPosition = new Vector2(currentPositionX, currentPositionY);
        }
        else
        {
            StartCoroutine(WaitForIt());
        }
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(2.0f);
    }
}
