using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueMng : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueTxt;

    private string[] dialogueLines;
    private int currentLineindex;

    private void Start()
    {
        dialoguePanel.SetActive(false);
    }

    private void ShowNextDialogue()
    {
        if (dialogueLines == null || currentLineindex >= dialogueLines.Length)
        {
            dialoguePanel.SetActive(false);
            return;
        }

        dialogueTxt.text = dialogueLines[currentLineindex];
        currentLineindex++;
    }

    private void Update()
    {
        if (dialoguePanel.activeSelf && Input.GetMouseButtonDown(0))
        {
            ShowNextDialogue();
        }
    }

    public void StartDialogue(string[] lines)
    {
        dialogueLines = lines;
        currentLineindex = 0;
        dialoguePanel.SetActive(true);
        ShowNextDialogue();
    }
}
