using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsDecrementer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Line"))
        {
            GameManager.instance.WrongPath();
        }    
    }
}
