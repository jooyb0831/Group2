using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BoxWindow : MonoBehaviour
{
    public TMP_Text boxName;
    public Box box;
    [SerializeField] TMP_InputField nameChange;


    public int windowNum = -1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnBoxColse()
    {
        gameObject.SetActive(false);
        BoxUI.Instance.boxes[windowNum].GetComponent<Box>().isOpen = false;
    }

    public void OnInputFieldOkBtn()
    {
        boxName.text = nameChange.text;
        box.GetComponent<Box>().boxData.boxTitle = boxName.text;
        nameChange.gameObject.SetActive(false);
    }
}
