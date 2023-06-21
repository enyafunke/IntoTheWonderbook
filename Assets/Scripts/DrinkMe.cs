using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkMe : MonoBehaviour
{
    [SerializeField] GameObject player; //camera rig
    bool smaller;
    Vector3 scale;
    Vector3 scaleSize = new Vector3(0.001f, 0.001f, 0.001f);

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("drink");
        smaller = true;
    }

    private void Update()
    {
        scale = player.transform.localScale;
        if (smaller && player.transform.localScale.y > 0.1f)
        {
            Debug.Log("resize");
            player.transform.localScale -= scaleSize;
        }
        else
        {
            smaller = false;
        }
    }
}
