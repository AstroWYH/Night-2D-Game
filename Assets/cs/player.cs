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

        // �����ƶ�����
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical) * speed * Time.deltaTime;

        // Ӧ���ƶ�
        transform.Translate(movement);
    }

}
