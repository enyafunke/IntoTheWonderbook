using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private AudioManager audio;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Door"))
            OpenDoor(collision.gameObject);

    }

    private void OpenDoor(GameObject door)
    {
        audio.PlayDoorSound(door.GetComponent<AudioSource>());
        door.GetComponent<Animator>().SetTrigger("open");
    }
}
