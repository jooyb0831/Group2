using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System;

public class MenuUI : MonoBehaviour
{
    public Image menuImg;
    public TextMeshProUGUI menuTxt1;
    public TextMeshProUGUI menuTxt2;
    public string originalTxt1;
    public string originalTxt2;
    public string defaultTxt1;
    public string defaultTxt2;

    public Button unpackBtn;

    private int currentIndex;

    private void Start()
    {
        // 메뉴를 검정색과 ???로 리셋
        menuImg.color = Color.black;
        menuTxt1.text = defaultTxt1;
        menuTxt2.text = defaultTxt2;
        currentIndex = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(UnpackMenu());
        }
    }

    IEnumerator UnpackMenu()
    {
        yield return new WaitForSeconds(1f);

         menuImg.color = Color.white;
         menuTxt1.text = originalTxt1;
         menuTxt2.text = originalTxt2;
    }

    /*void BuyRecipe()
    {
        if ()
        {
            GameUI.Instance.Gold

        }
    }*/
}