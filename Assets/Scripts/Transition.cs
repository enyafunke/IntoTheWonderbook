using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] GameObject mainWorld;
    [SerializeField] GameObject tutorial;
    [SerializeField] GameObject cameraRig;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(DoTransition());
    }

    public void StartTransition()
    {
        StartCoroutine(DoTransition());
    }

    IEnumerator DoTransition()
    {
        anim.SetTrigger("transition");
        
        yield return new WaitForSeconds(3);
        tutorial.SetActive(false);
        yield return new WaitForSeconds(1);
        cameraRig.SetActive(false);
        mainWorld.SetActive(true);
        anim.SetTrigger("transitionBack");
    }
}
