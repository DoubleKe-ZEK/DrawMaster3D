using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [Header(" Colors ")]
    public CustomGradient[] gradients;
    new MeshRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        SetRandomGradient();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRandomGradient()
    {
        gradients[Random.Range(0, gradients.Length)].SetColors(renderer.material);
    }
}

[System.Serializable]
public class CustomGradient
{
    public Color topColor;
    public Color botColor;

    public void SetColors(Material mat)
    {
        mat.SetColor("_ColorTop", topColor);
        mat.SetColor("_ColorMid", botColor);
    }
}
