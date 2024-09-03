using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemGet : MonoBehaviour
{
    float time = 3f;
    float timer;
    public Sprite icon;
    public TMP_Text itemTitle;
    public TMP_Text itemCount;
    public string itemTitleString;
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= time)
        {
            timer = 0;

            for (int i = 0; i < transform.parent.GetComponent<ItemGetBG>().itemTitles.Count; i++)
            {
                if(transform.parent.GetComponent<ItemGetBG>().itemTitles[i].Equals(itemTitle.text))
                {
                    transform.parent.GetComponent<ItemGetBG>().itemTitles.RemoveAt(i);
                    transform.parent.GetComponent<ItemGetBG>().itemGets.RemoveAt(i);
                    break;
                }
            }
            Destroy(gameObject);
        }
    }
}
