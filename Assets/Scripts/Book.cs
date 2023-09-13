using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField] GameObject line;
    [SerializeField] GameObject lineHand;
    public GameObject rabbit;
    public GameObject rabbit2;


    private void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.CompareTag("Rabbit"))
            {
                line.SetActive(false);
                /*other.gameObject.transform.localScale = new Vector3(.2f, 0f, .2f);
                other.gameObject.transform.parent = items.transform;
                other.gameObject.transform.localPosition = new Vector3(0, 0, -0.1f);
                other.gameObject.transform.eulerAngles = new Vector3(-70f, 0f, 180f);*/
                rabbit2.SetActive(true);
                rabbit.SetActive(false);
                other.GetComponent<AudioSource>().Play();
                lineHand.SetActive(true);
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
