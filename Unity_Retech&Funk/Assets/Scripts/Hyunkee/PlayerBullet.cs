using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        Invoke("DestroyBullet", 3);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
