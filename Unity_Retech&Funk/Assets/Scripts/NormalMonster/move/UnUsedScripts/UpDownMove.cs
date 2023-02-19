using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownMove : MonoBehaviour
{
    float UpMax = 3.5f; //�·� �̵������� (x)�ִ밪

    float DownMax = -3.5f; //��� �̵������� (x)�ִ밪

    float currentPositionY, currentPositionX; //���� ��ġ(x) ����

    float direction = 3.0f; //�̵��ӵ�+����




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

        //���� ��ġ(x)�� ��� �̵������� (x)�ִ밪���� ũ�ų� ���ٸ�

        //�̵��ӵ�+���⿡ -1�� ���� ������ ���ְ� ������ġ�� ��� �̵������� (x)�ִ밪���� ����

        else if (currentPositionY <= DownMax)

        {

            direction *= -1;

            currentPositionY = DownMax;

        }

        //���� ��ġ(x)�� �·� �̵������� (x)�ִ밪���� ũ�ų� ���ٸ�

        //�̵��ӵ�+���⿡ -1�� ���� ������ ���ְ� ������ġ�� �·� �̵������� (x)�ִ밪���� ����

        this.gameObject.transform.localPosition = new Vector2(currentPositionX, currentPositionY);
        //"Stone"�� ��ġ�� ���� ������ġ�� ó��

    }
}
