using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkMe : MonoBehaviour
{
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
}
