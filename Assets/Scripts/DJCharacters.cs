using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJCharacters : MonoBehaviour
{
    Animator animator;   
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.djCharactersMove)
        {
            animator.SetInteger("Animate", 1);
        }
    }
}
