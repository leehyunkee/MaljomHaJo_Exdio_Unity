using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Movement movement;

    private void Awake()
    {
        movement = GetComponent<Movement>();
    }

    private void Update()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement.MoveTo(new Vector3(x, y, 0));
    }
}
