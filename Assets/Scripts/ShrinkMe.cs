using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkMe : MonoBehaviour
{
    /* Shrink World
    public GameObject gameObject; 
    public GameObject gameObject2; 
    public GameObject gameObjectParent;
    [SerializeField] Camera camera;

    Vector3 scaleSize = new Vector3(0.01f, 0.01f, 0.01f);
    bool machmal = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        machmal = true;
        gameObjectParent.transform.position = new Vector3(
            camera.transform.position.x,
            0, camera.transform.position.z);
        gameObject.transform.parent = gameObjectParent.transform;
        gameObject2.transform.parent = gameObjectParent.transform;
    }

        // Update is called once per frame
        void Update()
    {
        if (machmal && gameObjectParent.transform.localScale.y < 10)
        {
            gameObjectParent.transform.localScale += scaleSize;
        }
        else
        {
            machmal = false;
        }
    }
    */

    // Shrink CameraRig
    public GameObject cameraRig;  
    public GameObject cameraRigParent;
    public GameObject cameraRigParentDone;
    [SerializeField] Camera camera;

    Vector3 scaleSize = new Vector3(0.0042f, 0.0042f, 0.0042f);
    bool machmal = false;
    [HideInInspector] public static bool isShrinking= false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Selector"))
        {
            if (cameraRigParent.transform.localScale.y > 0.2 && !GrowMe.isGrowing)
            {
                machmal = true;
                isShrinking = true;
            }

            cameraRigParent.transform.position = new Vector3(
                camera.transform.position.x,
                0, camera.transform.position.z);
            cameraRig.transform.parent = cameraRigParent.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (machmal && cameraRigParent.transform.localScale.y > 0.1)
        {
            cameraRigParent.transform.localScale -= scaleSize;
        }
        else
        {
            if (machmal)
            {
                cameraRig.transform.parent = cameraRigParentDone.transform;
                machmal = false;
                isShrinking = false;
            }
        }
    }
}
