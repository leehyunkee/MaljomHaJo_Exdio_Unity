using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secendmove : MonoBehaviour
{
    float UpMax = 3.0f; //�·� �̵������� (x)�ִ밪

    float DownMax = -3.0f; //��� �̵������� (x)�ִ밪

    float currentPositionY, currentPositionX; //���� ��ġ(x) ����

    float directionX, directionY; //�̵��ӵ�+����

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


        if (currentPositionX < -14 || currentPositionX > 14 || currentPositionY < -5 || currentPositionY > 5)
        {
            Destroy(gameObject);
        }
    }

    void updownmove()
    {
        directionY = 3.0f;

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
        directionX = -6.0f;
        currentPositionX += Time.deltaTime * directionX;
        this.gameObject.transform.localPosition = new Vector2(currentPositionX, currentPositionY);
    }

    void DiagonalDownMove()
    {
        directionX = -6.0f;
        directionY = -3.0f;

        currentPositionX += Time.deltaTime * directionX;
        currentPositionY += Time.deltaTime * directionY;
        this.gameObject.transform.localPosition = new Vector2(currentPositionX, currentPositionY);
    }

    void DiagonalUpMove()
    {
        directionX = -6.0f;
        directionY = 3.0f;

        currentPositionX += Time.deltaTime * directionX;
        currentPositionY += Time.deltaTime * directionY;
        this.gameObject.transform.localPosition = new Vector2(currentPositionX, currentPositionY);
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
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(2.0f);
    }
}
