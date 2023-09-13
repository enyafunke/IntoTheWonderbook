using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField] GameObject line;
    [SerializeField] GameObject lineHand;
    [SerializeField] private AudioSource rabbitSound;
    public GameObject rabbit;
    public GameObject rabbit2;


    private void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.CompareTag("Rabbit"))
            {
                rabbitSound.Play();
                line.SetActive(false);
                rabbit2.SetActive(true);
                rabbit.SetActive(false);
                lineHand.SetActive(true);
            }
        
    }
}
