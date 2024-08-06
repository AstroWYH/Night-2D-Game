using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform target; // 主角的Transform组件
    public float smoothSpeed = 0.125f; // 相机移动的平滑度
    public Vector2 offset = new Vector2(0.2f, 0.2f); // 边缘检测的偏移量

    private Camera cam;
    private float camHeight;
    private float camWidth;

    void Start()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Player").transform;
        }

        cam = Camera.main;
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = transform.position;
            Vector3 viewPos = cam.WorldToViewportPoint(target.position);
            //Debug.Log("viewPos:x: " + viewPos.x + "viewPos:y: " + viewPos.y);

            // 仅在接近屏幕边缘时移动相机
            if (viewPos.x > 1 - offset.x)
            {
                desiredPosition.x = target.position.x;
            }
            else if (viewPos.x < offset.x)
            {
                desiredPosition.x = target.position.x;
            }

            if (viewPos.y > 1 - offset.y)
            {
                desiredPosition.y = target.position.y;
            }
            else if (viewPos.y < offset.y)
            {
                desiredPosition.y = target.position.y;
            }

            // 使用插值平滑移动相机
            // 突然理解了这段代码，解决相机问题靠的是巧合...注意desiredPosition的赋值即可
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, -10);
        }
    }
}
