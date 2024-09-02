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
        //마우스 클릭한 좌표값 가져오기
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //해당 좌표에 있는 오브젝트 찾기
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        if (!hit)
        {
            //Debug.Log("나무가 없다");
            return;
        }
        else if (hit.collider.GetComponent<Tree>())
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                if(p.toolName.Equals("도끼"))
                {
                    if(p.data.SP<2)
                    {
                        Debug.Log("체력이 부족합니다.");
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
                            Debug.Log("너무 멀다");
                        }
                    }

                }
                else
                {
                    Debug.Log("도끼가 없습니다");
                }
                
            }
        }


        //if (Input.GetMouseButtonDown(0))
        //{
        //    //마우스 클릭한 좌표값 가져오기
        //    Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    //해당 좌표에 있는 오브젝트 찾기
        //    RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        //    if (!hit)
        //    {
        //        Debug.Log("나무가 없다");
        //    }
        //    else if (hit.collider.GetComponent<Tree>())
        //    {
        //        if (hit.collider.GetComponent<Tree>().sensePlayer)
        //        {
        //            hit.collider.GetComponent<Tree>().TreeCut--;
        //        }
        //        else
        //        {
        //            Debug.Log("너무 멀다");
        //        }
        //    }
        //}
    }
}
