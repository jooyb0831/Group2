using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : MonoBehaviour
{
    private Player p;
    [SerializeField] GameObject chatPanel;
    [SerializeField] GameObject questMark;
    public string charName = "민수";
    public string[] dialogueLines =
    {
        "마을에 온 것을 환영해요!",
        "처음 정착하는데 도움이 될 물건을 몇 개 가지고 왔어요.",
        "행운을 빌어요!"
    };

    public bool isDone = false;
    private bool isGivenItem = false;
    [SerializeField] GameObject test;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(p == null)
        {
            p = GameManager.Instance.player;
            return;
        }

        float dist = Vector2.Distance(p.transform.position, transform.position);

        if(dist<1)
        {
            if(Input.GetMouseButtonDown(0))
            {
                chatPanel.SetActive(true);
                DialogueMng.Instance.dialogueLines = dialogueLines;
                DialogueMng.Instance.NPCNameTxt.text = charName;
            }
        }
        if(isGivenItem == false)
        {
            if (isDone == true)
            {
                test.GetComponent<TestScript>().GiveItem();
                questMark.SetActive(false);
                isGivenItem = true;
            }
            else
            {
                return;
            }
        }

    }
}
