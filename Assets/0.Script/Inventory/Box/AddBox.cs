using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBox : MonoBehaviour
{
    [SerializeField] Transform boxGroup;
    [SerializeField] GameObject box;
    [SerializeField] GameObject boxWindow;

    public int boxNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    [SerializeField] Vector2 savePos = Vector2.zero;
    // Update is called once per frame
    void Update()
    {

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetMouseButtonDown(0))
        {
            savePos = pos;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject newBox = Instantiate(box, boxGroup);
            newBox.transform.position = savePos;
            GameObject window = Instantiate(boxWindow, BoxUI.Instance.position);
            newBox.GetComponent<Box>().boxData.boxIndex = boxNumber;
            window.GetComponent<BoxWindow>().windowNum = boxNumber;
            window.GetComponent<BoxWindow>().box = newBox.GetComponent<Box>();
            BoxUI.Instance.boxes.Add(newBox);
            BoxUI.Instance.boxInvenWindow.Add(window);
            newBox.GetComponent<Box>().boxData.boxTitle = $"상자 {boxNumber + 1}";
            window.GetComponent<BoxWindow>().boxName.text = $"상자 {boxNumber + 1}";
            boxNumber++;
        }
        
    }
}
