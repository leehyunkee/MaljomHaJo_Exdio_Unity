using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalDownMove : MonoBehaviour
{
    float currentPositionY, currentPositionX; //���� ��ġ(x) ����

    float directionX = -6.0f; //�̵��ӵ�+����
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
