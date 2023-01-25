using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyunkeeBullet : MonoBehaviour
{

    public float speed = 10f;

    private void Start()
    {
        //�������κ��� 2�� �� ����
        Destroy(gameObject, 2f);
    }

    private void Update()
    {
        //�ι�° �Ķ���Ϳ� Space.World�� �������ν� Rotation�� ���� ���� ������ ������
        transform.Translate(Vector2.left * speed * Time.deltaTime, Space.Self);
    }
}
