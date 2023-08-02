using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField] GameObject items;
    [SerializeField] GameObject line;
    bool key, drink, eat;
    public GameObject rabbit;
    [SerializeField] private AudioManager audio;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 3)
        {
            audio.PlayGegenstandSound(GetComponent<AudioSource>());
            if (other.gameObject.CompareTag("Key"))
            {
                key = true;
                other.gameObject.transform.parent = items.transform;
                //other.gameObject.transform.localPosition = new Vector3(0.5f, 0.5f, 0.5f);

            }
            if (other.gameObject.CompareTag("Eat"))
            {
                eat = true;
            }
            if (other.gameObject.CompareTag("Drink"))
            {
                drink = true;
            }
            if (other.gameObject.CompareTag("Rabbit"))
            {
                line.SetActive(false);
                other.gameObject.transform.localScale = new Vector3(.2f, .2f, .2f);
                other.gameObject.transform.parent = items.transform;
                other.gameObject.transform.localPosition = new Vector3(0, 0, -0.1f);
                other.gameObject.transform.eulerAngles = new Vector3(-70f, 0f, 180f);
            }
        }
    }

    /*private void Start()
    {
        rabbit.transform.localScale = new Vector3(.2f, .2f, .2f);
        rabbit.transform.parent = items.transform;
        rabbit.transform.localPosition = new Vector3(0, 0, -0.1f);
        rabbit.transform.eulerAngles = new Vector3(-70f, 0f, 180f);
    }*/
}
