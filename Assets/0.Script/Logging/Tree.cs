using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] treeSprites;
    [SerializeField] private Sprite stump;
    [SerializeField] private FieldItem lumber;

    public int treeCut;
    public int TreeCut
    {
        get
        {
            return treeCut;
        }
        set
        {
            GetComponent<TreeAM>().enabled = true;
            Invoke("StopAM", 0.1f);
            treeCut = value;
        }
    }
    private int lumberCut;
    public bool logging;
    public bool sensePlayer;
    private Player p;
    //public GameObject p;
    private Vector3 treeCenter;
    public int treeNumber;
    // Start is called before the first frame update
    void Start()
    {
        treeCut = 5;
        lumberCut = Random.Range(2, 6);
        logging = false;
        sensePlayer = false;
        p = GameManager.Instance.player;
        //p = GameObject.Find("[Player]");
        treeCenter = new Vector3(transform.position.x + 1, transform.position.y - 1, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(p==null)
        {
            p= GameManager.Instance.player;
            return;
        }
        float dis = Vector2.Distance(treeCenter, p.transform.position);
        if (dis <= 3f)
        {
            sensePlayer = true;
        }
        else
        {
            sensePlayer = false;
        }
        if (treeCut <= 0 && !logging)
        {
            for (int i = 0;i < treeSprites.Length;i++)
            {
                if (i == 10)
                {
                    treeSprites[i].sprite = stump;
                    treeSprites[i].transform.localScale = new Vector3(3, 3, 3);
                }
                else
                {
                    treeSprites[i].gameObject.SetActive(false);
                }
            }
            for (int i = 0;i < lumberCut;i++)
            {
                FieldItem l = Instantiate(lumber, transform.parent);
                l.transform.parent = transform.parent;
                l.transform.position = new Vector3(transform.position.x + 1,transform.position.y - 2, 0);
                //l.isFind = true;
            }
            logging = true;
            LoggingData.TreeData.treeData[treeNumber] = false;
        }
    }
    public void Logging()
    {
        if (!logging)
        {
            treeCut--;
        }
    }
    void StopAM()
    {
        GetComponent<TreeAM>().enabled = false;
        transform.position = new Vector2(treeCenter.x - 1, transform.position.y);
    }
}
