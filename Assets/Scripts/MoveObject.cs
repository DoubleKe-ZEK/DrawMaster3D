using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Vector3 moveDirection;
    public int speed;

    public bool delay;
    private void Update()
    {
        if(GameManager.instance.objectMove && !delay)
        {
            this.transform.Translate(moveDirection * speed * Time.deltaTime);
        }
        else if(GameManager.instance.objectMove && delay)
        {
            StartCoroutine(DelayBullet());
        }
    }

    IEnumerator DelayBullet()
    {
        yield return new WaitForSeconds(1);
        delay = false;
    }
}
