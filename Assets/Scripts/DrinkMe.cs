using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkMe : MonoBehaviour
{
    GameObject shrinkPillar;



    //Gemeinsame Variable für EatMe und DrinkMe, um zu verhindern, dass beide gleichzeitig aktiviert werden
    [HideInInspector]  public static bool resizeIsActive = false;
    [HideInInspector]  public static Vector3 originCameraRigPosition = new Vector3(0f,0f,0f);


    [SerializeField] GameObject cameraRig; //camera rig
    //[SerializeField] CameraRig cameraRig;
    [SerializeField] Camera camera;
    //[SerializeField] CameraRig cameraRig; 
    Vector3 originCamera;
    Vector3 originCameraRig;
    //bool finish = false;
    bool smaller;
    Vector3 scale;
    Vector3 scaleSize = new Vector3(0.001f, 0.001f, 0.001f);

    //Spawn Objects
    public GameObject objectToSpawn;
    [SerializeField] GameObject pillarCylinder;

    private void OnTriggerEnter(Collider other)
    {
        originCamera.x = camera.transform.position.x;
        originCamera.z = camera.transform.position.z;
        //originCamera.x = 0f;
        //originCamera.z = 0f;

        originCameraRig.x = cameraRig.transform.position.x;
        originCameraRig.z = cameraRig.transform.position.z;

        originCameraRigPosition = cameraRig.transform.position;

        //cameraRig.transform.position += new Vector3(camera.transform.position.x, 0f, camera.transform.position.z);
        //camera.transform.position = new Vector3(0f, camera.transform.position.y, 0f);
        //Debug.Log("rig " + cameraRig.transform.position.ToString());
        //Debug.Log("cam " + camera.transform.position.ToString());

        Debug.Log("drink");
        smaller = true;


        Vector3 shrinkPoint = new Vector3(0, 0, 0);
        shrinkPillar = Instantiate(pillarCylinder, shrinkPoint, Quaternion.identity);
        //Debug.Log("Shrink Pillar: " + shrinkPillar.)


        //spawn Key (+ cookies?)
        if (GameObject.FindGameObjectsWithTag("Key").Length == 0)
        {
            Debug.Log("FindGameObjects");
            spawnKey();
        }

        //if(spawnCookies(GameObject.FindGameObjectsWithTag("EatMe").Length == 0){
        //  spawnCookies();
        //}
    }

    void spawnKey()
    {   Vector3 keySpawnPosition = new Vector3(8, 0.2f, 25);
        GameObject key = Instantiate(objectToSpawn, keySpawnPosition, Quaternion.identity);
    }

    void spawnCookies()
    {
        Debug.Log("Cookies Spawned");
    }

    private void Update()
    {
        scale = cameraRig.transform.localScale;
        //if (!resizeIsActive && smaller && cameraRig.transform.localScale.y > 0.1f)
        if (smaller && cameraRig.transform.localScale.y > 0.1f)
        {
            resizeIsActive = true;
            //Debug.Log("Resize Smaller: " + resizeIsActive);
            //Debug.Log("resize");

            //Debug.Log("cam x "+cameraRig.transform.position.x*camera.transform.position.x+"\n"+"\t cam z "+cameraRig.transform.position.z*camera.transform.position.z);
            //camera.transform.position = new Vector3(0f, camera.transform.position.y, 0f);
            //Debug.Log("cam res " + camera.transform.position.ToString());
            cameraRig.transform.localScale -= scaleSize;
            //cameraRig.transform.position = new Vector3(
            //    cameraRig.transform.position.x + (camera.transform.position.x - cameraRig.transform.position.x - (originCamera.x - originCameraRig.x) * 0.999f) * 0.001f,
            //    0,
            //    cameraRig.transform.position.z + (camera.transform.position.z - cameraRig.transform.position.z - (originCamera.z - originCameraRig.z) * 0.999f) * 0.001f
            //    );

            // Nicht bewegen:
            // cameraRig.transform.position = new Vector3(
            //     cameraRig.transform.position.x + (originCamera.x - originCameraRig.x) * 0.001f,
            //     0,
            //     cameraRig.transform.position.z + (originCamera.z - originCameraRig.z) * 0.001f
            //     );

            //finish = true;
            // 6cam+3rig=6cam*0,1+6rig+(3orig-0,6cam)
            //9=0,6+8,4rig(6+2,4)
            //9=0,6+8,4rig(3+5,4)
            //cameraRig.transform.position = new Vector3(
            //    cameraRig.transform.position.x + (originCameraRig.x+ (camera.transform.position.x-(camera.transform.position.x * 0.001f))) * 0.001f,
            //    0,
            //    cameraRig.transform.position.z + (originCameraRig.z+ (camera.transform.position.z-(camera.transform.position.z * 0.001f))) * 0.001f
            //    );
            // Camera ändert Werte nicht beim schrumpfen --> bewegungs änderung nächstes Mal hinzuaddieren?
            // cameraRig.transform.position = new Vector3(
            //     cameraRig.transform.position.x + (camera.transform.position.x) * (1f- cameraRig.transform.localScale.x),
            //     0,
            //     cameraRig.transform.position.z + (camera.transform.position.z) * (1f- cameraRig.transform.localScale.z)
            //     );

            // cameraRig um scale weiter schieben
            // cameraRig.transform.position = new Vector3(
            //     cameraRig.transform.position.x +  (camera.transform.position.x* (scaleSize.x))/(camera.transform.position.x),
            //     0,
            //     cameraRig.transform.position.z - camera.transform.position.z *2* (scaleSize.z)
            //     );

            // cameraRig.transform.position = new Vector3(
            //     cameraRig.transform.position.x + (camera.transform.position.x - cameraRig.transform.position.x) * (2*scaleSize.x),
            //     0,
            //     cameraRig.transform.position.z + (camera.transform.position.z - cameraRig.transform.position.z) * (0.5f*scaleSize.z)
            //     );
            cameraRig.transform.position = new Vector3(
                cameraRig.transform.position.x + (camera.transform.position.x - originCameraRig.x) * (scaleSize.x),
                0,
                cameraRig.transform.position.z + (camera.transform.position.z - originCameraRig.z) * (scaleSize.z)
                );

            Vector3 shrinkcenter = GetGroundIntersectionPoint(originCameraRigPosition, cameraRig.transform.position, pillarCylinder.transform.position);
            //pillarCylinder.transform.position.x = (shrinkcenter.x + (camera.transform.position.x - originCameraRig.x) * (scaleSize.x));
            //pillarCylinder.transform.position.z = (shrinkcenter.z + (camera.transform.position.z - originCameraRig.z) * (scaleSize.z));
            //pillarCylinder.transform.position = new Vector3(

            //shrinkcenter.x + (camera.transform.position.x - originCameraRig.x) * (scaleSize.x),
            //0,
            //(shrinkcenter.z + (camera.transform.position.z - originCameraRig.z) * (scaleSize.z))
            //);

            pillarCylinder.transform.position = new Vector3(

            shrinkcenter.x + (camera.transform.position.x ) * (scaleSize.x),
            0,
            (shrinkcenter.z + (camera.transform.position.z ) * (scaleSize.z))
            );

            //Debug.Log(GetGroundIntersectionPoint(originCameraRigPosition, cameraRig.transform.position) + (camera.transform.position - originCameraRig) * (scaleSize));
            Debug.Log(pillarCylinder.transform.position);

            //shrinkPillar.transform.position = GetGroundIntersectionPoint(originCameraRigPosition, cameraRig.transform.position) + ((camera.transform.position - originCameraRig).multiply(scale));


        }
        else
        {
            //if (finish)
            //{
            //    finish = false;
            //    //cameraRig.transform.position = new Vector3((0.1f*..x), 0f, (0.1f*originCamera.z));
            //}
            smaller = false;
            resizeIsActive = false;
        }

        /* Feature: Fly Steuerung um Ursprung 
         * [SerializeField] GameObject cameraRig; //camera rig
    //[SerializeField] CameraRig cameraRig;
    [SerializeField] Camera camera;
    //[SerializeField] CameraRig cameraRig; 
    Vector3 originCamera;
    Vector3 originCameraRig;
    //bool finish = false;
    bool smaller;
    Vector3 scale;
    Vector3 scaleSize = new Vector3(0.001f, 0.001f, 0.001f);

    private void OnTriggerEnter(Collider other)
    {
        originCamera.x = camera.transform.position.x;
        originCamera.z = camera.transform.position.z;
        //originCamera.x = 0f;
        //originCamera.z = 0f;

        originCameraRig.x = cameraRig.transform.position.x;
        originCameraRig.z = cameraRig.transform.position.z;

        //cameraRig.transform.position += new Vector3(camera.transform.position.x, 0f, camera.transform.position.z);
        //camera.transform.position = new Vector3(0f, camera.transform.position.y, 0f);
        //Debug.Log("rig " + cameraRig.transform.position.ToString());
        //Debug.Log("cam " + camera.transform.position.ToString());

        Debug.Log("drink");
        smaller = true;
    }

    private void Update()
    {
        scale = cameraRig.transform.localScale;
        if (smaller && cameraRig.transform.localScale.y > 0.1f)
        {
            //Debug.Log("resize");

            //camera.transform.position = new Vector3(0f, camera.transform.position.y, 0f);
            //Debug.Log("cam res " + camera.transform.position.ToString());
            cameraRig.transform.localScale -= scaleSize;
            cameraRig.transform.position = new Vector3(
                cameraRig.transform.position.x + (originCamera.x - originCameraRig.x ) *0.001f + (camera.transform.position.x- cameraRig.transform.position.x) *0.999f,
                0,
                cameraRig.transform.position.z + (originCamera.z - originCameraRig.z ) *0.001f + (camera.transform.position.z-cameraRig.transform.position.z )*0.999f
                );
            //finish = true;
        }
        else
        {
            //if (finish)
            //{
            //    finish = false;
            //    //cameraRig.transform.position = new Vector3((0.1f*originCamera.x), 0f, (0.1f*originCamera.z));
            //}
            smaller = false;
        }*/
    }

    private Vector3 GetGroundIntersectionPoint(Vector3 originalPosition, Vector3 newPosition, Vector3 elsePosition)
    {
        Ray ray = new Ray(originalPosition, newPosition - originalPosition);
        RaycastHit hit;

        int masklayer = 1 << 6;
        //if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
        //if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("ShrinkRay")))
        //if (Physics.Raycast(ray, out hit, Mathf.Infinity, masklayer))
        if (Physics.Raycast(ray, out hit, masklayer))
        {
            Debug.Log("hit");
            return hit.point;
        }

        // Wenn keine Schnittstelle gefunden wurde, gib die ursprüngliche Position zurück.
        return elsePosition;
    }
}
