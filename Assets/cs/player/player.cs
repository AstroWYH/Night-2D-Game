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
    public bool inputDisable = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        eventhandler.BeforeSceneUnloadEvent += OnBeforeSceneUnloadEvent;
        eventhandler.AfterSceneLoadedEvent += OnAfterSceneLoadedEvent;
        eventhandler.MoveToPosition += OnMoveToPosition;
    }

    private void OnMoveToPosition(Vector3 targetPosition)
    {
        transform.position = targetPosition;
    }

    private void OnBeforeSceneUnloadEvent()
    {
        inputDisable = true;//player���ɿ�
    }

    private void OnAfterSceneLoadedEvent()
    {
        inputDisable = false;
    }

    private void Update()
    {
        if (!inputDisable)
            PlayerInput();
    }

    private void FixedUpdate()
    {
        if (!inputDisable)
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

    // ͨ��rb�ƶ�
    private void Movement()
    {
        rb.MovePosition(rb.position + movementInput * speed * Time.deltaTime);
    }

    // ͨ��transform�ƶ������е㲻���֣�
    //void Update()
    //{
    //    float horizontal = Input.GetAxis("Horizontal");
    //    float vertical = Input.GetAxis("Vertical");

    //    // �����ƶ�����
    //    Vector3 movement = new Vector3(horizontal, vertical, 0.0f) * speed * Time.deltaTime;

    //    // ��������ʱ��Ӧ���ƶ�
    //    if (horizontal != 0 || vertical != 0)
    //    {
    //        transform.Translate(movement);
    //    }
    //}
}
