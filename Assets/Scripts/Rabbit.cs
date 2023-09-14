using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class Rabbit : MonoBehaviour
{
    [SerializeField] private Transition tran;
    [SerializeField] private AudioSource rabbitSound;
    private bool transitionStart = false; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Selector"))
        {
            if (!transitionStart)
                transitionStart = true;
                Debug.Log(("collided"));
                tran.StartTransition();
                rabbitSound.Play(0);
        }
    }

    private void Start()
    {
        //tran.StartTransition();
    }
}
