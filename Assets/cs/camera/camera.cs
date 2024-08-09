using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform target; // ���ǵ�Transform���
    public float smoothSpeed = 0.125f; // ����ƶ���ƽ����
    public Vector2 offset = new Vector2(0.2f, 0.2f); // ��Ե����ƫ����

    private Camera cam;
    //private float camHeight;
    //private float camWidth;

    void Start()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Player").transform;
        }

        cam = Camera.main;
        //camHeight = 2f * cam.orthographicSize;
        //camWidth = camHeight * cam.aspect;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = transform.position;
            Vector3 viewPos = cam.WorldToViewportPoint(target.position);
            //Debug.Log("viewPos:x: " + viewPos.x + "viewPos:y: " + viewPos.y);

            // ���ڽӽ���Ļ��Եʱ�ƶ����
            if (viewPos.x > 1 - offset.x || viewPos.x < offset.x)
            {
                desiredPosition.x = target.position.x;
            }

            if (viewPos.y > 1 - offset.y || viewPos.y < offset.y)
            {
                desiredPosition.y = target.position.y;
            }

            // ʹ�ò�ֵƽ���ƶ����
            // �����ڱ�ԵͻȻ��desiredPosition��ֵΪ��ɫλ�ã����������ͻȻ���м�������ɫ������ɳ���˲�ƣ��Ҵ�ʱ��ɫ�Ͳ���offset����
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, -10);
        }
    }
}
