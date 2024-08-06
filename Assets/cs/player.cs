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
        Vector3 movement = new Vector3(horizontal, vertical, 0.0f) * speed * Time.deltaTime;

        // ��������ʱ��Ӧ���ƶ�
        if (horizontal != 0 || vertical != 0)
        {
            transform.Translate(movement);
        }
    }

}
