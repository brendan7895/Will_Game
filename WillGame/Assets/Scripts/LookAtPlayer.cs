using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        //gameObject.transform.Rotate(-180, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(target);
    }
}
