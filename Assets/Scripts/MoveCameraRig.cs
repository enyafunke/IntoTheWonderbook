using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraRig : MonoBehaviour
{
    [SerializeField] Camera camera;

    // Update is called once per frame
    void Update()
    {
        Vector3 vec = new Vector3(camera.transform.position.x - transform.position.x, 0, camera.transform.position.z - transform.position.z);
        transform.position = vec;
    }
}
