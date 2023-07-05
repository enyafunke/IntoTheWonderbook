using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatMe : MonoBehaviour
{
    [SerializeField] GameObject cameraRig; //camera rig
    [SerializeField] Camera camera;
    Vector3 originCamera;
    Vector3 originCameraRig;
    bool bigger;
    Vector3 scaleSize = new Vector3(0.001f, 0.001f, 0.001f);



    private void OnTriggerEnter(Collider other)
    {
        originCamera.x = camera.transform.position.x;
        originCamera.z = camera.transform.position.z;

        originCameraRig.x = cameraRig.transform.position.x;
        originCameraRig.z = cameraRig.transform.position.z;

        Debug.Log("Eat");
        bigger = true;
    }


    // Update is called once per frame
    void Update()
    {
        {
            //scale = cameraRig.transform.localScale;
            if (!DrinkMe.resizeIsActive && bigger && cameraRig.transform.localScale.y < 1)
            {
                DrinkMe.resizeIsActive = true;

                Debug.Log("Resize Bigger: " + DrinkMe.resizeIsActive);
                cameraRig.transform.localScale += scaleSize;

                
                
                cameraRig.transform.position = new Vector3(
                cameraRig.transform.position.x - (camera.transform.position.x - originCameraRig.x) * (scaleSize.x),
                0,
                cameraRig.transform.position.z - (camera.transform.position.z - originCameraRig.z) * (scaleSize.z)
                );
                

                
            }
            else
            {
                DrinkMe.resizeIsActive = false;
                bigger = false;
            }
        }
    }
}
