using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    float currentPositionY, currentPositionX; //현재 위치(x) 저장

    float directionX = -6.0f; //이동속도+방향
    float directionY = 3.0f;
    float timer;



    void Start()

    {
        currentPositionX = this.gameObject.transform.localPosition.x;
        currentPositionY = this.gameObject.transform.localPosition.y;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer < 1)
        {
            currentPositionX += Time.deltaTime * directionX;
            currentPositionY += Time.deltaTime * directionY;
            this.gameObject.transform.localPosition = new Vector2(currentPositionX, currentPositionY);
        }
        else if (timer >= 1 || timer < 2)
        {
            Debug.Log("A");
            StartCoroutine(WaitForIt());
        }
        else if (timer >= 2 || timer <3)
        {
            Debug.Log("D");
            currentPositionX += -Time.deltaTime * directionX;
            currentPositionY += -Time.deltaTime * directionY;
            this.gameObject.transform.localPosition = new Vector2(currentPositionX, currentPositionY);
        }

    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(2.0f);
    }
}
