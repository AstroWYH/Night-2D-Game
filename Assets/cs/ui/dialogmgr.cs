using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogmgr : MonoBehaviour
{
    private GameObject dialogueBox; // 对话框的 GameObject
    private Text dialogueText; // 对话框中的 Text 组件
    public string[] dialogueMessages; // 对话框显示的消息数组
    public bool playerInRange = false;
    public bool dialogueStarted = false;
    private int currentDialogueIndex = 0;

    private void Awake()
    {
        dialogueBox = GameObject.Find("dialogbox");
        dialogueText = GameObject.Find("dialogtext").GetComponent<Text>();
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

    public void ShowDialogue()
    {
        if (dialogueMessages.Length > 0)
        {
            dialogueBox.SetActive(true);
            dialogueText.text = dialogueMessages[currentDialogueIndex];
        }
    }

    public void ShowNextDialogue()
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

    public void HideDialogue()
    {
        dialogueBox.SetActive(false);
        currentDialogueIndex = 0;
    }
}

