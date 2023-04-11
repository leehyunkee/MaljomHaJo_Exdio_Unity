using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 0.0f;
    public Vector3 moveDirection = Vector3.zero;

    Camera mainCamera;
    float objectWidth;
    float objectHeight;

    private void Start()
    {
        mainCamera = Camera.main;
        objectWidth = transform.localScale.x;
        objectHeight = transform.localScale.y;
    }
    private void Update()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(x, y, 0);
        Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;

        float leftEdge = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + objectWidth;
        float rightEdge = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - objectWidth;
        float topEdge = mainCamera.ViewportToWorldPoint(new Vector3(0, 1f, 0)).y - objectHeight;
        float bottomEdge = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + objectHeight;

        newPosition = new Vector3(Mathf.Clamp(newPosition.x, leftEdge, rightEdge),
            Mathf.Clamp(newPosition.y, bottomEdge, topEdge),
            transform.position.z);

        //MoveTo(new Vector3(x, y, 0));
        //transform.position += moveDirection * moveSpeed * Time.deltaTime;
        transform.position = newPosition;
    }

        
    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}
