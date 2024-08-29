using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    private string dialogueSceneName = "NPC_ChatUI";
    private string[] dialogueLines = 
    { 
        "���1",
        "���2",
        "���3"
    };

    private void Start()
    {
        if (!SceneManager.GetSceneByName(dialogueSceneName).isLoaded)
        {
            SceneManager.LoadScene(dialogueSceneName, LoadSceneMode.Additive);
        }
    }

    private void OnMouseDown()
    {
        GameObject dialogueManagerObj = GameObject.Find("DialogueMng");
        if (dialogueManagerObj != null)
        {
            DialogueMng dialogueManager = dialogueManagerObj.GetComponent<DialogueMng>();
            if (dialogueManager != null)
            {
                dialogueManager.StartDialogue(dialogueLines);
            }
        }
    }

}
