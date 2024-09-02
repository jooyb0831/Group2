using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logging : MonoBehaviour
{
    [SerializeField] private Player p;
    // Start is called before the first frame update
    void Start()
    {
        if (p == null)
        {
            p = GameManager.Instance.player;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(p == null)
        {
            p = GameManager.Instance.player;
            return;
        }
        //���콺 Ŭ���� ��ǥ�� ��������
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //�ش� ��ǥ�� �ִ� ������Ʈ ã��
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        if (!hit)
        {
            //Debug.Log("������ ����");
            return;
        }
        else if (hit.collider.GetComponent<Tree>())
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                if(p.toolName.Equals("����"))
                {
                    if(p.data.SP<2)
                    {
                        Debug.Log("ü���� �����մϴ�.");
                    }
                    else
                    {
                        if (hit.collider.GetComponent<Tree>().sensePlayer)
                        {
                            p.data.SP -= 2;
                            hit.collider.GetComponent<Tree>().TreeCut--;
                        }
                        else
                        {
                            Debug.Log("�ʹ� �ִ�");
                        }
                    }

                }
                else
                {
                    Debug.Log("������ �����ϴ�");
                }
                
            }
        }


        //if (Input.GetMouseButtonDown(0))
        //{
        //    //���콺 Ŭ���� ��ǥ�� ��������
        //    Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    //�ش� ��ǥ�� �ִ� ������Ʈ ã��
        //    RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        //    if (!hit)
        //    {
        //        Debug.Log("������ ����");
        //    }
        //    else if (hit.collider.GetComponent<Tree>())
        //    {
        //        if (hit.collider.GetComponent<Tree>().sensePlayer)
        //        {
        //            hit.collider.GetComponent<Tree>().TreeCut--;
        //        }
        //        else
        //        {
        //            Debug.Log("�ʹ� �ִ�");
        //        }
        //    }
        //}
    }
}
