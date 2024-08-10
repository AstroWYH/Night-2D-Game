using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogmgr : MonoBehaviour
{
    private GameObject dialogueBox; // �Ի���� GameObject
    private Text dialogueText; // �Ի����е� Text ���
    public string[] dialogueMessages; // �Ի�����ʾ����Ϣ����
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
                ShowDialogue(); // ��ʾ��һ��Ի�
                dialogueStarted = true; // ��ǶԻ���ʼ
            }
            else
            {
                ShowNextDialogue(); // ��ʾ��һ��Ի�
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

