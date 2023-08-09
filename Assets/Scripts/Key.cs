using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collide: " + collision.gameObject);
        Debug.Log("collide tag: " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Door"))
            OpenDoor();

    }

    private void OpenDoor()
    {
        Debug.Log("open door");
    }
}
