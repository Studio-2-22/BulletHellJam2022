using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformDampFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;

    public Vector3 targetOffset;

    private void Start()
    {
        
    }

    private void Update()
    {   
        Vector3 desiredPosition = target.position + (target.rotation * targetOffset);
       // Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = desiredPosition;
    }

}
