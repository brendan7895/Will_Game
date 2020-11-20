using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed = 25;
    public float strafeSpeed = 7.5f;
    public float hoverSpeed = 5;

    private float activeForwardSpeed;
    private float activeStrafeSpeed;
    private float activeHoverSpeed;

    private float forwardAcceleration = 2.5f;
    private float strafeAcceleration = 2;
    private float hoverAcceleration = 2;

    public float lookRotateSpeed = 90;
    private Vector2 lookInput;
    private Vector2 screenCenter;
    private Vector2 mouseDistance;

    Vector3 rot;
    
    private float rollInput;
    public float rollSpeed = 90;
    public float rollAcceleration = 3.5f;

    float rotationRoll = 360;
    float rotationSpeed = 500;
    bool startRoll = false;

    ////float speed = 15;
    //float turnSmoothTime = 0.1f;
    //float turnSmoothVelocity;
    //public Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        screenCenter.x = Screen.width / 2;
        screenCenter.y = Screen.height / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //float h = Input.GetAxisRaw("Horizontal");
        //float v = Input.GetAxisRaw("Vertical");

        //Vector3 direction = new Vector3(h, 0, v).normalized;

        //if(direction.magnitude >= 0.1f)
        //{
        //    float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        //    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        //    transform.rotation = Quaternion.Euler(0, angle, 0);

        //    Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
        //    transform.position += moveDirection.normalized * forwardSpeed * Time.deltaTime;
        //}

        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1);

        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);

        

        transform.Rotate(-mouseDistance.y * lookRotateSpeed
            * Time.deltaTime, Mathf.Clamp(mouseDistance.x, -45, 45) * lookRotateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);

        //transform.Rotate(-mouseDistance.y * lookRotateSpeed
        //    * Time.deltaTime, mouseDistance.x * lookRotateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);

        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical")
            * forwardSpeed, forwardAcceleration * Time.deltaTime);

        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal")
            * strafeSpeed, strafeAcceleration * Time.deltaTime);

        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover")
            * hoverSpeed, hoverAcceleration * Time.deltaTime);

        // Boost mechanic - checks if the user is holding down shift
        if (Input.GetKey("left shift"))
        {
            transform.position += transform.forward * activeForwardSpeed * Time.deltaTime * 2;
            transform.position += transform.right * activeStrafeSpeed * Time.deltaTime * 2;
            transform.position += transform.up * activeHoverSpeed * Time.deltaTime * 2;
        }
        else
        {
            transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
            transform.position += transform.right * activeStrafeSpeed * Time.deltaTime;
            transform.position += transform.up * activeHoverSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Tab) && !startRoll)
        {
            startRoll = true;

            //removes the camera as a child
            //Camera.main.transform.parent = null;          
        }

        if (startRoll)
        {
            Roll();
        }
    }

    
    void Roll()
    {
        float rotation = rotationSpeed * Time.deltaTime;
        if (rotationRoll > rotation)
        {
            rotationRoll -= rotation;
        }
        else
        {
            rotation = rotationRoll;
            rotationRoll = 0;
           
            //sets the camera parent to the game object
            //Camera.main.transform.SetParent(this.transform);

            startRoll = false;
            rotationRoll = 360;           
        }
        transform.Rotate(0, 0, rotation);

        //rotates the camera the oppisite way around its own axis not the parent
        //Camera.main.transform.Rotate(0, 0, -rotation);

        
    }

}
