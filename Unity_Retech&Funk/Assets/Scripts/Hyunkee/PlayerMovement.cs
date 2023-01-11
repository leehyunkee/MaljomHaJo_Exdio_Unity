using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 0.0f;
    public Vector3 moveDirection = Vector3.zero;
    private void Update()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        MoveTo(new Vector3(x, y, 0));
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

        
    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}
