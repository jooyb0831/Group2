using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : MonoBehaviour
{
    private Player p;
    [SerializeField] GameObject chatPanel;
    [SerializeField] GameObject questMark;
    public string charName = "�μ�";
    public string[] dialogueLines =
    {
        "������ �� ���� ȯ���ؿ�!",
        "ó�� �����ϴµ� ������ �� ������ �� �� ������ �Ծ��.",
        "����� �����!"
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
