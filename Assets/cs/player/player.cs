using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    private float inputX;
    private float inputY;
    private Vector2 movementInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // 通过transform移动（有点不跟手）
    //void Update()
    //{
    //    float horizontal = Input.GetAxis("Horizontal");
    //    float vertical = Input.GetAxis("Vertical");

    //    // 计算移动方向
    //    Vector3 movement = new Vector3(horizontal, vertical, 0.0f) * speed * Time.deltaTime;

    //    // 当有输入时才应用移动
    //    if (horizontal != 0 || vertical != 0)
    //    {
    //        transform.Translate(movement);
    //    }
    //}

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void PlayerInput()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        if (inputX != 0 && inputY != 0)
        {
            inputX = inputX * 0.6f;
            inputY = inputY * 0.6f;
        }

        movementInput = new Vector2(inputX, inputY);
    }

    // 通过rb移动
    private void Movement()
    {
        rb.MovePosition(rb.position + movementInput * speed * Time.deltaTime);
    }

}
