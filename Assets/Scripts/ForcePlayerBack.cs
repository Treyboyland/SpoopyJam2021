using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePlayerBack : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D playerBody;

    [SerializeField]
    float forcePower;

    [SerializeField]
    float secondsBetweenForceApplications;

    bool isForcingBack = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        CheckForStop(collision);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        CheckForStop(collision);
    }

    void CheckForStop(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();
        if (player && isForcingBack)
        {
            StopAllCoroutines();
            isForcingBack = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();
        if (player && !isForcingBack)
        {
            StartCoroutine(AddForce());
        }
    }

    IEnumerator AddForce()
    {
        isForcingBack = true;
        while (true)
        {
            Vector2 forceVector = (transform.position - playerBody.transform.position).normalized;
            playerBody.AddForce(forceVector * forcePower);
            yield return new WaitForSeconds(secondsBetweenForceApplications);
        }
    }
}
