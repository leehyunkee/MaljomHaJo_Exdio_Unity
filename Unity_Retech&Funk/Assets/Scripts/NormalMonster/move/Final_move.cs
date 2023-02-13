using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final_move : MonoBehaviour
{
    float UpMax = 2.0f; //�·� �̵������� (x)�ִ밪

    float DownMax = -2.0f; //��� �̵������� (x)�ִ밪

    float currentPositionY, currentPositionX; //���� ��ġ(x) ����

    float directionX, directionY; //�̵��ӵ�+����

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

        //���� ��ġ(x)�� ��� �̵������� (x)�ִ밪���� ũ�ų� ���ٸ�

        //�̵��ӵ�+���⿡ -1�� ���� ������ ���ְ� ������ġ�� ��� �̵������� (x)�ִ밪���� ����

        else if (currentPositionY <= DownMax)

        {

            directionY *= -1;


        }

        //���� ��ġ(x)�� �·� �̵������� (x)�ִ밪���� ũ�ų� ���ٸ�

        //�̵��ӵ�+���⿡ -1�� ���� ������ ���ְ� ������ġ�� �·� �̵������� (x)�ִ밪���� ����

        this.gameObject.transform.localPosition = new Vector2(currentPositionX, currentPositionY);
        //"Stone"�� ��ġ�� ���� ������ġ�� ó��

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
