using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    Animator anim;
    [SerializeField] AudioSource openDoorSound;
    [SerializeField] GameObject fog;
    [SerializeField] GameObject text;
    [SerializeField] private AudioSource keySound;

    Boolean bookInArea = false;
    Boolean keyPressed = false;



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            bookInArea = true;
            //anim.SetTrigger("openDoor");
        }
        if (other.gameObject.CompareTag("Selector"))
        {
            keyPressed = true;
            if (bookInArea)
            {
                anim.SetTrigger("openDoor");
                if (fog.activeSelf == false)
                {
                    openDoorSound.Play(0);
                    fog.SetActive(true);
                    text.SetActive(true);
                    keySound.Play(0);
                }
            }
        }
        
    }

    void OnTriggerLeave(Collider other)
    {
        //if (other.gameObject.CompareTag("Door"))
        //{
        //    bookInArea = false;
        //}

        }

        // Start is called before the first frame update
        void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Door").GetComponent<Animator>();
         

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}