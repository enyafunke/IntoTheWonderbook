using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField] GameObject items;
    bool key, drink, eat;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 3)
        {
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
        }
    }
}
