using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class Rabbit : MonoBehaviour
{
    [SerializeField] private Transition tran;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Selector"))
        {
            Debug.Log(("collided"));
            tran.StartTransition();
        }
    }

    private void Start()
    {
        //tran.StartTransition();
    }
}
