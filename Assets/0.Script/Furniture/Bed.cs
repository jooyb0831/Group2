using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Bed : MonoBehaviour
{
    public static Bed Instance { get; private set; }

    public Transform bedPosition;
    public GameObject selectPanel;
    public CanvasGroup screenFader;

    public TextMeshProUGUI subtitleTxt;
    public float Distance = 1f;
    public Transform player;

    private void Start()
    {
        if (bedPosition == null)
        {
            bedPosition = GameObject.Find("Bed").transform;
        }

        if (selectPanel == null)
        {
            selectPanel = GameObject.Find("notice");
        }

        if (screenFader == null)
        {
            screenFader = GameObject.Find("Fade").GetComponent<CanvasGroup>();
        }
    }

    private void Update()
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
        Vector2 dirToPlayer = player.position - transform.position;
        dirToPlayer.Normalize();

        Ray ray = new Ray(transform.position, dirToPlayer);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Distance))
        {
            return hit.transform == player;
        }

        return false;
    }

    private void Interact()
    {
        subtitleTxt.text = "휴식을 취하시겠습니까?";
        SceneChanger.Instance.ToSleep();
    }

    private IEnumerator FadeScreen()
    {
        float duration = 2f;
        float currentime = 0f;

        while (currentime < duration)
        {
            currentime += Time.deltaTime;
            screenFader.alpha = Mathf.Lerp(0, 1, currentime / duration);
            yield return null;
        }
    }

    public void OnYesClicked()
    {
        selectPanel.SetActive(false);
        player.transform.position = bedPosition.position;
        StartCoroutine(FadeScreen());
        //TimeSystem
    }

    public void OnNoCliked()
    {
        selectPanel.SetActive(false);
    }
}
