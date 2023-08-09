using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowMe : MonoBehaviour
{
    // Grow CameraRig
    public GameObject cameraRig;
    public GameObject cameraRigParent;
    public GameObject cameraRigParentDone;
    [SerializeField] Camera camera;

    Vector3 scaleSize = new Vector3(0.0042f, 0.0042f, 0.0042f);
    bool machmal = false;
    [HideInInspector] public static bool isGrowing = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Selector"))
        {
            if (cameraRigParent.transform.localScale.y < 0.9 && !ShrinkMe.isShrinking)
            {
                machmal = true;
                isGrowing = true;
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
        if (machmal && cameraRigParent.transform.localScale.y < 1)
        {
            cameraRigParent.transform.localScale += scaleSize;
        }
        else
        {
            if (machmal)
            {
                cameraRig.transform.parent = cameraRigParentDone.transform;
                machmal = false;
                isGrowing = false;
            }
        }
    }
}
