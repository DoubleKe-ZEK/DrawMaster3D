using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    int screeWidth;
    int screenHeight;

    private void Awake()
    {
        screeWidth = Screen.width;
        screenHeight = Screen.height;

        if(screeWidth == 720 && screenHeight == 1280)
        {
            Camera.main.orthographicSize = 5;
        }
        else if(screeWidth == 1080 && (screenHeight == 2340 || screenHeight == 2400))
        {
            Camera.main.orthographicSize = 6;
        }

    }
}
