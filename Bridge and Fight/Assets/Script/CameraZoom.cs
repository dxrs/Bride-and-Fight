using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public List<Transform> camTarget;

    public Vector3 offset;

    //smooth cam movement
    [Header("Smooth Camera Movement")]
    public float smoothTime = .5f;

    [Header("Camera Zoom")]//camera zoom
    public float minZoom = 5f;
    public float maxZoom = 7f;
    public float zoomLimiter = 5f;


    Vector3 velocity;

    Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
        //cam.orthographicSize = 10;
    }
    private void LateUpdate()
    {
        if (camTarget == null) { return; }

        if (!PlayerDestroy.playerDestroy.isGameOver
            &&GameStarting.gameStarting.isGameStarted)
        {
            
            cameraZoom();
            if (!PlayerTrigger.playerTrigger.isP1_ColtoCamEdge && !PlayerTrigger.playerTrigger.isP2_ColtoCamEdge) 
            {
                cameraMovement();
            }
        }
       


    }

    void cameraMovement() 
    {
        Vector3 centerPoint = getCenterPoint();
        Vector3 newPos = centerPoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPos,
            ref velocity, smoothTime);
    }

    void cameraZoom() 
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, boundDistance() / zoomLimiter);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom,Time.deltaTime);
    }

    float boundDistance() 
    {
        var bounds = new Bounds(camTarget[0].position, Vector2.zero);
        for (int j = 0; j < camTarget.Count; j++)
        {
            bounds.Encapsulate(camTarget[j].position);
        }



        return bounds.size.x+bounds.size.y;
        
    }

    Vector3 getCenterPoint() 
    {
        if (camTarget.Count == 1) 
        {
            return camTarget[0].position;
        }
        var bounds = new Bounds(camTarget[0].position, Vector2.zero);
        for(int j = 0; j < camTarget.Count; j++) 
        {



            bounds.Encapsulate(camTarget[j].position);


        }
        return bounds.center;
    }


}
