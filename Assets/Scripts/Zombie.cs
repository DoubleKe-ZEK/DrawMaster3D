using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Vector3 characterPosition;
    public bool destroy;
    public GameObject objects;

    Animator animator;
    Rigidbody rb;

    private void Awake()
    {
        animator = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Car"))
        {
            if(animator)
            {
                animator.SetInteger("Zanim", 1);
            }
            //rb.AddForce(new Vector3(-1, 0, 0) * 100);
            //rb.AddForce(Vector3.up * 200);
            GameManager.instance.CharacterAnimate();
            rb.AddForce(characterPosition * 200);
            if (destroy)
            {
                Destroy(other.gameObject);
                if(objects)
                {
                    Destroy(objects);
                }
            }
        }
    }
}
