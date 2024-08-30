using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (SceneManager.GetActiveScene().name != ("Farm"))
        {
            gameObject.SetActive(false);
        }
        else if(SceneManager.GetActiveScene().name == ("Farm"))
        {
            gameObject.SetActive(true);
        }
        
        if (SceneChanger.Instance.isFarm == true)
        {
            gameObject.SetActive(true);
        }
        else if (SceneChanger.Instance.isFarm == false)
        {
            gameObject.SetActive(false);
        }
        */
    }
}
