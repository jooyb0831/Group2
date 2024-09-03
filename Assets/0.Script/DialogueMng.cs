using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueMng : Singleton<DialogueMng>
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueTxt;
    public TMP_Text NPCNameTxt;
    public string[] dialogueLines;
    private int currentLineindex;
    [SerializeField] GameObject npc;
    private void Start()
    {
        
    }

    private void ShowNextDialogue()
    {
        if (dialogueLines == null || currentLineindex >= dialogueLines.Length)
        {
            dialoguePanel.SetActive(false);
            npc.GetComponent<Talk>().isDone = true;
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
        //dialoguePanel.SetActive(true);
        ShowNextDialogue();
    }
}
