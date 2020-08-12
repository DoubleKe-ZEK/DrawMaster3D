using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmanager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource _As;
    public static soundmanager instance;
    public AudioClip levelcomplete,draw, objectForm;
    void Awake()
    {
        if (instance)
        {
            DestroyImmediate(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    // Update is called once per frame
    public void playmysound(AudioClip sound)
    {
        _As.PlayOneShot(sound);
    }
}
