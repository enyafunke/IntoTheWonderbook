using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatMe : MonoBehaviour
{
    [SerializeField] GameObject cameraRig; //camera rig
    [SerializeField] Camera camera;
    Vector3 originCamera;
    Vector3 originCameraRig;
    Vector3 growthTriggerPosition;
    bool bigger;
    Vector3 scaleSize = new Vector3(0.001f, 0.001f, 0.001f);



    private void OnTriggerEnter(Collider other)
    {
        originCamera.x = camera.transform.position.x;
        originCamera.z = camera.transform.position.z;

        originCameraRig = DrinkMe.originCameraRigPosition;
        // originCameraRig.z = cameraRig.transform.position.z;

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
                /* 

                // Ansatz vorher
                DrinkMe.resizeIsActive = true;

                Debug.Log("Resize Bigger: " + DrinkMe.resizeIsActive);
                cameraRig.transform.localScale += scaleSize;

                
                cameraRig.transform.position = new Vector3(
                cameraRig.transform.position.x + (originCameraRig.x - camera.transform.position.x ) * (scaleSize.x),
                0,
                cameraRig.transform.position.z + (originCameraRig.z - camera.transform.position.z) * (scaleSize.z)
                );
                */

                /*
                // Ansatz 1:
                float scaleChange = 0.01f; // Schrumpf- oder Wachstumsänderung pro Update
                float newScale = transform.localScale.y - scaleChange; // Neue Skalierung des CameraRigs

                // Überprüfe, ob das CameraRig kleiner als der gewünschte Schrumpf ist
                if (newScale < 0.1f)
                {
                    // Aktiviere das Wachsen des CameraRigs zur Ursprungsposition
                    newScale = Mathf.Min(newScale + scaleChange, 0.1f); // Inkrementiere die Skalierung

                    // Berechne den Wachstumsmittelpunkt basierend auf der Ursprungsposition
                    Vector3 growthCenter = originPosition + transform.up * newScale * 0.5f;

                    // Berechne die Änderung der Position des CameraRigs basierend auf dem Wachstumsmittelpunkt
                    Vector3 positionChange = growthCenter - transform.position;

                    // Aktualisiere die Position des CameraRigs
                    transform.position = growthCenter;

                    // Aktualisiere die Skalierung des CameraRigs
                    transform.localScale = new Vector3(newScale, newScale, newScale);
                }
                */

                /*
                // Ansatz 2
                // if (transform.localScale.y < originalScale.y) // Wachsen
                // {
                    

                    // 
                    float newScale = transform.localScale.x + scaleChange;
                    newScale = Mathf.Min(newScale, originalScale.x);

                    Vector3 positionChange = (transform.localScale.x - newScale) * transform.up;
                    transform.position += positionChange;

                    // transform.localScale = new Vector3(newScale, newScale, newScale);

                    // Überprüfe, ob das Wachstum ausgelöst werden soll
                    if (transform.position == growthTriggerPosition)
                    {
                        // Starte das Wachstum
                        // ...
                    }
                // }
                */

                // Ansatz 3

                // Skalierung
                cameraRig.transform.localScale += scaleSize;

                cameraRig.transform.position = new Vector3(
                cameraRig.transform.position.x + (originCameraRig.x - camera.transform.position.x ) * (scaleSize.x),
                0,
                cameraRig.transform.position.z + (originCameraRig.z - camera.transform.position.z) * (scaleSize.z)
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
