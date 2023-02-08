using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletshot : MonoBehaviour
{

    public GameObject bullet1; // �Ѿ� ������Ʈ
    public GameObject bullet2;
    Vector2 pos;

    void Start()
    {
        StartCoroutine("Shot"); //�ݺ��ؼ� �Լ� ����
        StartCoroutine("Shot2");
        //pos = this.gameObject.transform.localPosition; //������ ���� ��ġ
    }


    IEnumerator Shot()
    {

        GameObject temp = Instantiate(bullet1); // �Ѿ� ����
        pos = gameObject.transform.position;
        temp.transform.position = pos; // ������ ���� ��ġ���� �Ѿ� ����
        yield return new WaitForSecondsRealtime(0.3f); // 3�� �������� ����
        StartCoroutine("Shot"); //�ݺ��ؼ� �Լ� ����

    }

    IEnumerator Shot2()
    {

        GameObject temp = Instantiate(bullet2); // �Ѿ� ����
        pos = gameObject.transform.position;
        temp.transform.position = pos; // ������ ���� ��ġ���� �Ѿ� ����
        yield return new WaitForSecondsRealtime(1.0f); // 3�� �������� ����
        StartCoroutine("Shot2"); //�ݺ��ؼ� �Լ� ����

    }
}