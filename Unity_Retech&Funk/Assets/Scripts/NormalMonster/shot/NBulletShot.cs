using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NBulletShot : MonoBehaviour
{

    public GameObject bullet; // �Ѿ� ������Ʈ
    Vector2 pos;

    void Start()
    {
        StartCoroutine("Shot"); //�ݺ��ؼ� �Լ� ����
        //pos = this.gameObject.transform.localPosition; //������ ���� ��ġ
    }


    IEnumerator Shot()
    {

        GameObject temp = Instantiate(bullet); // �Ѿ� ����
        pos = gameObject.transform.position;
        temp.transform.position = pos; // ������ ���� ��ġ���� �Ѿ� ����
        yield return new WaitForSeconds(0.3f); // 3�� �������� ����
        StartCoroutine("Shot"); //�ݺ��ؼ� �Լ� ����

    }
}
