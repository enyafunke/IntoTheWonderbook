using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] private GameObject Bottle_static;
    [SerializeField] private GameObject Cookie_static;
    [SerializeField] private GameObject Key_static;
    [SerializeField] private GameObject Bottle_item;
    [SerializeField] private GameObject Cookie_item;
    [SerializeField] private GameObject Key_item;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Eat"))
        {
            Cookie_static.SetActive(false);
            Cookie_item.SetActive(true);
            Debug.Log("Eat me funktioniert");
        }
        
        if (other.gameObject.CompareTag("Drink"))
        {
            Bottle_static.SetActive(false);
            Bottle_item.SetActive(true);
            Debug.Log("Drink me funktioniert");
        }
        
        if (other.gameObject.CompareTag("Key"))
        {
            Key_static.SetActive(false);
            Key_item.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}