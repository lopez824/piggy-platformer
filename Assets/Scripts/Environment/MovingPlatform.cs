using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private bool isOnPlatform = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && isOnPlatform == false)
        {
            isOnPlatform = true;
            Debug.Log("On Platform");
            collision.gameObject.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isOnPlatform = false;
            Debug.Log("Off Platform");
            collision.gameObject.transform.parent = null;
        }
    }
}
