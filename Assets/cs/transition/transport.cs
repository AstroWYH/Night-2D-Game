using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transport : MonoBehaviour
{
    public string sceneToGo;
    public Vector3 positionToGo;//����

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))//�ж��Ƿ������
        {
            eventhandler.CallTransitionEvent(sceneToGo, positionToGo);
        }
    }
}
