using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterZone : MonoBehaviour
{
    [SerializeField] WaterCanData waterData;
    private Player p;
    bool isPlace = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(p==null)
        {
            p = GameManager.Instance.player;
            return;
        }
        if(waterData == null)
        {
            waterData = GameManager.Instance.waterCanData;
            return;
        }
        if(isPlace ==true)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Debug.Log("��ä���");
                waterData.CurWater = waterData.MaxWater;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() && collision.GetComponent<Player>().toolName.Equals("���Ѹ���"))
        {
            Debug.Log("��");
            isPlace = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>())
        {
            isPlace = false;
        }
    }
}
