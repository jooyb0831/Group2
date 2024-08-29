using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TV : MonoBehaviour
{
    public static TV Instance { get; private set; }

    public Transform tvPosition;
    public GameObject selectPanel;

    public TextMeshProUGUI subtitleTxt;
    public TextMeshProUGUI answerTxt1;
    public TextMeshProUGUI answerTxt2;
    public float Distance = 1f;
    public Transform player;

    void Start()
    {
        if (tvPosition == null)
        {
            tvPosition = GameObject.Find("TVPosition").transform;
        }
        if (selectPanel == null)
        {
            selectPanel = GameObject.Find("SelectPanel");
        }
    }

    void Update()
    {
        if (LookingAtObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                Interact();
            }
        }
    }

    private bool LookingAtObject()
    {
        Vector2 dir = player.position - transform.position;
        dir.Normalize();

        Ray ray = new Ray(transform.position, dir);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Distance))
        {
            return hit.transform == player;
        }

        return false;
    }

    private void Interact()
    {
        subtitleTxt.text = "무엇을 보시겠습니까?";
        answerTxt1.text = "날씨";
        answerTxt2.text = "(TV끄기)";
        SceneChanger.Instance.WatchTV();
    }

    public void OnWeatherButtonClicked()
    {
        selectPanel.SetActive(true);
    }

    public void OnNoButtonClicked()
    {
        selectPanel.SetActive(false);
    }
}
