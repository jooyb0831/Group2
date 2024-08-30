using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TreeSpon : MonoBehaviour
{
    [SerializeField] private TimeSystem ts;
    [SerializeField] private Transform[] sponPoints;
    [SerializeField] private Tree[] trees;
    [SerializeField] private GameObject stump;

    private void Awake()
    {
        var obj = FindObjectsOfType<GameObject>();
        for (int i = 0;i < obj.Length;i++)
        {
            if (obj[i].name == "stump(Clone)")
            {
                Destroy(obj[i]);
            }
        }
    }
    void Start()
    {
        if(ts == null)
        {
            ts = GameManager.Instance.timeSystem;
        }
        //���� ��������Ʈ ǥ�� ��������Ʈ ����
        for (int i = 0;i < sponPoints.Length;i++)
        {
            sponPoints[i].GetComponent<SpriteRenderer>().enabled = false;
        }


        //��¥�� �ٲ������
        if (LoggingData.Date.date != ts.Date)
        {
            for (int i = 0; i < sponPoints.Length; i++)
            {
                Tree t = Instantiate(trees[Random.Range(0, trees.Length)]);
                t.transform.position = sponPoints[i].position;
                LoggingData.TreeData.treeData[i] = true;
                t.treeNumber = i;
            }
            LoggingData.Date.date = ts.Date;
        }
        //��¥�� �ٲ��� �ʾ�����
        else
        {
            for (int i = 0; i < sponPoints.Length; i++)
            {
                if (LoggingData.TreeData.treeData[i] == false)
                {
                    GameObject g = Instantiate(stump);
                    g.transform.position = new Vector3(sponPoints[i].position.x + 1, sponPoints[i].position.y - 2, sponPoints[i].position.z);
                }
                else
                {
                    Tree t = Instantiate(trees[Random.Range(0, trees.Length)]);
                    t.transform.position = sponPoints[i].position;
                    LoggingData.TreeData.treeData[i] = true;
                    t.treeNumber = i;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //���߿� ġƮ
        if (Input.GetKeyDown(KeyCode.F9))
        {
            SceneManager.LoadScene("TESTSCENE 1");
        }
        if (Input.GetKeyDown(KeyCode.F10))
        {
            LoggingData.Date.date++;
        }
    }
}
