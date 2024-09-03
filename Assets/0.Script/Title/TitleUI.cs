using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TitleUI : MonoBehaviour
{
    [SerializeField] private Image optionsWid;
    [SerializeField] private TMP_InputField setName;
    [SerializeField] private Image setNameWid;
    [SerializeField] private Image reconfirmWid;
    [SerializeField] private TMP_Text refimWidTxt;
    [SerializeField] private TMP_Text limLetter;
    [SerializeField] private PlayerData pData;

    [HideInInspector] public string myName;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        pData = GameManager.Instance.pData;
    }

    // Update is called once per frame
    void Update()
    {
        refimWidTxt.text = $"닉네임이 \"{myName}\"으로(로) 설정됩니다";

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            limLetter.gameObject.SetActive(false);
        }
    }
    public void OutGame()
    {
        Application.Quit();
    }
    public void OpenOptWid()
    {
        optionsWid.gameObject.SetActive(true);
    }
    public void CloseOptWid()
    {
        optionsWid.gameObject.SetActive(false);
    }
    public void OpenSetName()
    {
        setNameWid.gameObject.SetActive(true);
    }
    public void SetName()
    {
        if (setName.text.Length > 7)
        {
            limLetter.gameObject.SetActive(true);
            timer = 2;
            return;
        }
        myName = setName.text;
        reconfirmWid.gameObject.SetActive(true);
        setNameWid.gameObject.SetActive(false);
    }
    public void ReSetName()
    {
        reconfirmWid.gameObject.SetActive(false);
        setNameWid.gameObject.SetActive(true);
    }
    public void GoGame()
    {
        pData.playerName = myName;
        SceneChanger.Instance.GoGame();

    }
}
