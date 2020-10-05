using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    float wantedRotationAngleSide;
    float currentRotationAngleSide;
    float wantedRotationAngleUp;
    float currentRotationAngleUp;
    Quaternion currentRotation;
    float rotationDamping = 3;
    float distance = 15.0f;
    float height = 5.0f;

    void LateUpdate()
    {
        wantedRotationAngleSide = target.eulerAngles.y;
        currentRotationAngleSide = transform.eulerAngles.y;

        wantedRotationAngleUp = target.eulerAngles.x;
        currentRotationAngleUp = transform.eulerAngles.x;

        currentRotationAngleSide = Mathf.LerpAngle(currentRotationAngleSide, wantedRotationAngleSide, rotationDamping * Time.deltaTime);

        currentRotationAngleUp = Mathf.LerpAngle(currentRotationAngleUp, wantedRotationAngleUp, rotationDamping * Time.deltaTime);

        currentRotation = Quaternion.Euler(currentRotationAngleUp, currentRotationAngleSide, 0);

        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;

        transform.LookAt(target);

        transform.position += transform.up * height;
    }
}
