using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TransitionSteamVR : MonoBehaviour
{
    [SerializeField] GameObject mainWorld;
    [SerializeField] GameObject tutorial;
    [SerializeField] GameObject cameraRigTutorial;
    [SerializeField] private AudioSource rabbitSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Selector"))
        {
            Debug.Log(("collided"));
            StartCoroutine(DoTransition());
            rabbitSound.Play(0);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    IEnumerator DoTransition()
    {
        fadeOut();
        yield return new WaitForSeconds(6);
        tutorial.SetActive(false);
        cameraRigTutorial.SetActive(false);
        mainWorld.SetActive(true);
        fadeIn();
        
        
    }

    void fadeOut()
    {
        SteamVR_Fade.Start(Color.clear, 0);
        SteamVR_Fade.Start(Color.black, 5);
    }
    void fadeIn()
    {
        SteamVR_Fade.Start(Color.black, 0);
        SteamVR_Fade.Start(Color.clear, 5);
    }

}
