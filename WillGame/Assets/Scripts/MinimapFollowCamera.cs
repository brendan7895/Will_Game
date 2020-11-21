using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapFollowCamera : MonoBehaviour
{
    public Transform target;

    float rotationDamping = 3;
    float distance = 15.0f;
    float height = 3.0f;

    void LateUpdate()
    {
       

        transform.position = target.position;
        //transform.position -= currentRotation * Vector3.forward * distance;

        transform.LookAt(target);

        transform.position += transform.up * height;
    }
}
