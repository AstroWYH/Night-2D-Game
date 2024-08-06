using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 5.0f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // 计算移动方向
        Vector3 movement = new Vector3(horizontal, vertical, 0.0f) * speed * Time.deltaTime;

        // 当有输入时才应用移动
        if (horizontal != 0 || vertical != 0)
        {
            transform.Translate(movement);
        }
    }

}
