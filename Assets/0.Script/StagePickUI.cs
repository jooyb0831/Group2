using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class StagePickUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StageSetting()
    {
        switch (gameObject.name)
        {
            case "1":
                {
                    VSDefine.presentStage = 1;
                    break;
                }
            case "2":
                {
                    VSDefine.presentStage = 2;
                    break;
                }
            case "3":
                {
                    VSDefine.presentStage = 3;
                    break;
                }
            case "4":
                {
                    VSDefine.presentStage = 4;
                    break;
                }
            case "5":
                {
                    VSDefine.presentStage = 5;
                    break;
                }
            default:
                {
                    Debug.Log("¿À·ù");
                    break;
                }
        }
        SceneManager.LoadScene("VampSur");
        SceneManager.LoadScene("VampSurUI", LoadSceneMode.Additive);
    }
}
