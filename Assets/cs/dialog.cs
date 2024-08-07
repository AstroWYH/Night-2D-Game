using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class dialog : MonoBehaviour
{
    private GameObject dialogueBox; // 对话框的 GameObject
    private Text dialogueText; // 对话框中的 Text 组件
    private string[] dialogueMessages; // 对话框显示的消息数组

    private bool playerInRange = false;
    private bool dialogueStarted = false;
    private int currentDialogueIndex = 0;

    private void Awake()
    {
        dialogueBox = GameObject.Find("dialogbox");
        dialogueText = GameObject.Find("dialogtext").GetComponent<Text>();

        dialogueMessages = new string[]
        {
            "和尚：天地不仁...",
            "和尚：咳咳，小施主，你可知下一句？",
            "和尚：诛仙世界，启动！"
        };

        dialogueBox.SetActive(false);
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Space))
        {
            if (!dialogueStarted)
            {
                ShowDialogue(); // 显示第一句对话
                dialogueStarted = true; // 标记对话开始
            }
            else
            {
                ShowNextDialogue(); // 显示下一句对话
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            HideDialogue();
            dialogueStarted = false; // 重置对话状态
        }
    }

    void ShowDialogue()
    {
        if (dialogueMessages.Length > 0)
        {
            dialogueBox.SetActive(true);
            dialogueText.text = dialogueMessages[currentDialogueIndex];
        }
    }

    void ShowNextDialogue()
    {
        currentDialogueIndex++;
        if (currentDialogueIndex < dialogueMessages.Length)
        {
            dialogueText.text = dialogueMessages[currentDialogueIndex];
        }
        else
        {
            HideDialogue();
        }
    }

    void HideDialogue()
    {
        dialogueBox.SetActive(false);
        currentDialogueIndex = 0;
    }
}
