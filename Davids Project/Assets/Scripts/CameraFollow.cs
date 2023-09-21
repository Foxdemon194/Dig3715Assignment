using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followObject;
    public Vector3 cameraPos;

    void Start()
    {
        cameraPos = transform.position - followObject.transform.position;
    }
    /*
    void Update()
    {
    Vector3 newPosition = followObject.transform.position + cameraPos;
    transform.position = newPosition;
    }
    */
    void LateUpdate()
    {
        Vector3 newPosition = followObject.transform.position + cameraPos;
        transform.position = newPosition;
    }

}