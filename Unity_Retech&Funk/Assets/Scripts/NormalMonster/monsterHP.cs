using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterHP : MonoBehaviour
{
    float currentPositionY, currentPositionX; //현재 위치(x) 저장
    // Start is called before the first frame update
    void Start()
    {
        currentPositionX = this.gameObject.transform.localPosition.x;
        currentPositionY = this.gameObject.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPositionX < -11 || currentPositionX > 11 || currentPositionY < -11 || currentPositionY > 11)
        {
            Destroy(gameObject);
        }
    }
}
