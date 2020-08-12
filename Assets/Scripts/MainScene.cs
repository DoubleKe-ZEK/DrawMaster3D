using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    private void Awake()
    {
        int levelNo = PlayerPrefs.GetInt("Level No. ", 1);
        SceneManager.LoadScene(levelNo);
    }
}
