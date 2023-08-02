using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowMe : MonoBehaviour
{
    // Grow CameraRig
    public GameObject cameraRig; 
    // public GameObject gameObject2; 
    public GameObject cameraRigParent;
    [SerializeField] Camera camera;

    Vector3 scaleSize = new Vector3(0.01f, 0.01f, 0.01f);
    bool machmal = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (cameraRigParent.transform.localScale.y < 0.9)
        {
            machmal = true;
        }
        cameraRigParent.transform.position = new Vector3(
            camera.transform.position.x,
            0, camera.transform.position.z);
        cameraRig.transform.parent = cameraRigParent.transform;
        // gameObject2.transform.parent = cameraRigParent.transform;
    }

        // Update is called once per frame
        void Update()
    {
        if (machmal && cameraRigParent.transform.localScale.y < 1)
        {
            cameraRigParent.transform.localScale += scaleSize;
        }
        else
        {
            machmal = false;
        }
    }
}