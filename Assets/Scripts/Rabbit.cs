using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class Rabbit : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject transitionPlane;
    bool startTransition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            StartCoroutine(ToWonderland());
        }
    }

    IEnumerator ToWonderland()
    {
        anim.SetTrigger("transition");
        //transitionPlane.SetActive(true);
        //startTransition = true;

        yield return new WaitForSeconds(5);

        SceneManager.LoadScene(1);
    }

    private void Start()
    {
        StartCoroutine(ToWonderland());
    }

    /*private void Update()
    {
        if(startTransition)
        {
            Color color = transitionPlane.GetComponent<Material>().color;

            if (color.a < 255)
            {
                color.a++;
                transitionPlane.GetComponent<Material>().color = color;
            }
        }
    }*/
}
