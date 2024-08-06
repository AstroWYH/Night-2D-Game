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
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical) * speed * Time.deltaTime;

        // 应用移动
        transform.Translate(movement);
    }

}
