using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class dialog : MonoBehaviour
{
    private GameObject dialogueBox; // �Ի���� GameObject
    private Text dialogueText; // �Ի����е� Text ���
    private string[] dialogueMessages; // �Ի�����ʾ����Ϣ����

    private bool playerInRange = false;
    private bool dialogueStarted = false;
    private int currentDialogueIndex = 0;

    private void Awake()
    {
        dialogueBox = GameObject.Find("dialogbox");
        dialogueText = GameObject.Find("dialogtext").GetComponent<Text>();

        dialogueMessages = new string[]
        {
            "���У���ز���...",
            "���У��ȿȣ�Сʩ�������֪��һ�䣿",
            "���У��������磬������"
        };

        dialogueBox.SetActive(false);
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Space))
        {
            if (!dialogueStarted)
            {
                ShowDialogue(); // ��ʾ��һ��Ի�
                dialogueStarted = true; // ��ǶԻ���ʼ
            }
            else
            {
                ShowNextDialogue(); // ��ʾ��һ��Ի�
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
            dialogueStarted = false; // ���öԻ�״̬
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
