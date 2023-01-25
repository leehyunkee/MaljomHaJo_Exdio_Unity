using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleShot : MonoBehaviour
{

    public GameObject bullet; // �Ѿ� ������Ʈ
    Vector2 pos;

    public int angleInterval = 10;
    public int startAngle = 0;
    public int endAngle = 360;

    void Start()
    {
        StartCoroutine("Shot"); //�ݺ��ؼ� �Լ� ����
        pos = gameObject.transform.position;
        //pos = this.gameObject.transform.localPosition; //������ ���� ��ġ
    }


    IEnumerator Shot()
    {

        while (true)
        {

            for (int fireAngle = startAngle; fireAngle < endAngle; fireAngle += angleInterval)
            {
                GameObject temp = Instantiate(bullet);
                temp.transform.position = pos;
                Vector2 direction = new Vector2(Mathf.Cos(fireAngle * Mathf.Rad2Deg), Mathf.Sin(fireAngle * Mathf.Rad2Deg)); //�ӽ�(������ ���׶��� ����)

                temp.transform.right = direction;
                temp.transform.position = transform.position;
            }

            yield return new WaitForSeconds(2.0f); 
            StartCoroutine("Shot"); //�ݺ��ؼ� �Լ� ����

        }

    }


}
