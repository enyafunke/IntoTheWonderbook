using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField]LineRenderer lineRenderer;
    [SerializeField] GameObject rabbit;
    [SerializeField] GameObject book;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(book.transform.position, rabbit.transform.position) < 3)
        {
            if(!lineRenderer.gameObject.activeSelf)
                lineRenderer.gameObject.SetActive(true);
            lineRenderer.SetPosition(0, book.transform.position);
            lineRenderer.SetPosition(1, rabbit.transform.position);
        }
        else
        {
            lineRenderer.gameObject.SetActive(false);
        }
    }
}