using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Transform farBackground;
    public Transform nearBackground;

    public float smoothSpeed = 0.125f;

    private float lastXPos;
    private float lastYPos;

    private void Start()
    {
        lastXPos = target.position.x;
        lastYPos = target.position.y;
    }

    private void Update()
    {   
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
       // Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        float amountToMoveX = transform.position.x - lastXPos;
        float amountToMoveY = transform.position.y - lastYPos;
        farBackground.position += new Vector3(amountToMoveX, amountToMoveY, 0);
        nearBackground.position += new Vector3(amountToMoveX* .8f , amountToMoveY * .8f , 0);
        lastXPos = transform.position.x;
        lastYPos = transform.position.y;
    }

}
