using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
    public GameObject hintPanel;
    public GameObject hintButton;
    public TextMeshProUGUI levelNoText;

    int levelNo;


    private void Awake()
    {
        levelNo = SceneManager.GetActiveScene().buildIndex;
        levelNoText.text = "Level " + levelNo.ToString();
    }


    public void HintOn()
    {
        hintPanel.SetActive(true);
        hintButton.SetActive(false);
        AdManager.instance.ShowAd();
    }
    public void HintOff()
    {
        hintPanel.SetActive(false);
        hintButton.SetActive(true);
    }

    public void Reload()
    {
        SceneManager.LoadScene(levelNo);
        //PlayerPrefs.SetInt("adseevery3", PlayerPrefs.GetInt("adseevery3") + 1);
        //if (PlayerPrefs.GetInt("adseevery3") == 4)
        //{
        //    AdManager.instance.ShowAd();
        //    PlayerPrefs.SetInt("adseevery3", 0);
        //}
       

    }

    public void Next()
    {
        levelNo++;
        PlayerPrefs.SetInt("Level No. ", levelNo);
        if(levelNo > 50)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(levelNo);
        }
        PlayerPrefs.SetInt("adseevery2", PlayerPrefs.GetInt("adseevery2") + 1);
        if (PlayerPrefs.GetInt("adseevery2") == 4)
        {
           // AdManager.instance.ShowAd();
            PlayerPrefs.SetInt("adseevery2", 0);
        }
    }
    public void Pp()
    {
        Application.OpenURL("https://unconditionalgames.blogspot.com/2020/01/privacy-policy-this-privacy-policy.html");
    }
    public void onRewardButtonPress()
    {
       // AdManager.instance.hint = true;
       // AdManager.instance.ShowAd();
}   }
