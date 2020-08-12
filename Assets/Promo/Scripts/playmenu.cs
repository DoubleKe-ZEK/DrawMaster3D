using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playmenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void play()
    {
        SceneManager.LoadScene(2);
    }
    public void PP()
    {
        Application.OpenURL("https://hypercausualgamesfree.s3.ap-south-1.amazonaws.com/hypercausualgames/Satisfying.txt");
    }
}
