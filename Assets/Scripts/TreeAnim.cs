using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAnim : MonoBehaviour
{
    Animator tree1;
    Animator tree2;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Book"))
        {
         tree1.SetTrigger("treeBends"); 
         tree2.SetTrigger(("treeBends"));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        tree1 = GameObject.FindGameObjectWithTag("Tree1").GetComponent<Animator>();
        tree2 = GameObject.FindGameObjectWithTag("Tree2").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
