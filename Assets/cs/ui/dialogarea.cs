using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;


public class dialogarea : MonoBehaviour
{
    private dialogmgr diamgr;
    public string[] dialogueMsgs;

    private void Start() // 这里不能用awake，因为那时dialogmgr很可能还没有
    {
        diamgr = FindObjectOfType<dialogmgr>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            diamgr.playerInRange = true;
            diamgr.dialogueMessages = dialogueMsgs;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            diamgr.playerInRange = false;
            diamgr.HideDialogue();
            diamgr.dialogueStarted = false; // 重置对话状态
        }
    }
}
