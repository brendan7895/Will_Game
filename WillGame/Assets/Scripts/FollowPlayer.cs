using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerTransform;

    Vector3 cameraOffset;

    public bool lookAtPlayer = false;
    public bool rotateAroundPlayer = true;

    public float rotationSpeed = 5;

    [Range(0.01f, 1f)]//adds a slider to unity to control
    public float smooth = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - playerTransform.position;
    }

    // called after the update method
    void LateUpdate()
    {
        if (rotateAroundPlayer)
        {
            Quaternion cameraTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") *
                rotationSpeed, Vector3.up); //maybe space.world

            cameraOffset = cameraTurnAngle * cameraOffset;
        }

        Vector3 newPos = playerTransform.position + cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, smooth);//smooths the transform

        if (lookAtPlayer || rotateAroundPlayer)
        {
            transform.LookAt(playerTransform);
        }
    }

}
