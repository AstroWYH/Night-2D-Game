using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform target; // 主角的Transform组件
    public float smoothSpeed = 0.125f; // 相机移动的平滑度
    public Vector2 offset = new Vector2(0.2f, 0.2f); // 边缘检测的偏移量

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

            // 仅在接近屏幕边缘时移动相机
            if (viewPos.x > 1 - offset.x || viewPos.x < offset.x)
            {
                desiredPosition.x = target.position.x;
            }

            if (viewPos.y > 1 - offset.y || viewPos.y < offset.y)
            {
                desiredPosition.y = target.position.y;
            }

            // 使用插值平滑移动相机
            // 不能在边缘突然将desiredPosition赋值为角色位置，否则相机会突然从中间跳到角色处，造成场景瞬移，且此时角色就不在offset内了
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, -10);
        }
    }
}
