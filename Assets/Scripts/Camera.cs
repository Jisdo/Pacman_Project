using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform targetCamera;
    public float smoothSpeed;
    public Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 positionCamera = targetCamera.localPosition + offset;
        Vector3 smoothCamera = Vector3.Lerp(transform.position, positionCamera, smoothSpeed);
        transform.position = smoothCamera;
    }
}
