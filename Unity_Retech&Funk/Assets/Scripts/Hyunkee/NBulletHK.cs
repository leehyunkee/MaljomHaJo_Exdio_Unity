using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NBulletHK : MonoBehaviour
{

    public GameObject bullet; // �Ѿ� ������Ʈ
    Vector2 pos;

    void Start()
    {
        StartCoroutine("Shot"); //�ݺ��ؼ� �Լ� ����
        pos = gameObject.transform.position;
        //pos = this.gameObject.transform.localPosition; //������ ���� ��ġ
    }


    IEnumerator Shot()
    {

        GameObject temp = Instantiate(bullet); // �Ѿ� ����
        temp.transform.position = pos; // ������ ���� ��ġ���� �Ѿ� ����
        yield return new WaitForSeconds(0.3f); // 3�� �������� ����
        StartCoroutine("Shot"); //�ݺ��ؼ� �Լ� ����

    }
    
}
