using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallKick : MonoBehaviour
{
    public GameObject ball;
    public Vector3 ballDirection;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = ball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Kick()
    {
        ball.transform.parent = null;
        rb.useGravity = true;
        rb.AddForce(ballDirection);
    }
}
