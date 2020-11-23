using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(target);

        if(gameObject.tag == "Shrimp")
        {
            gameObject.transform.Rotate(-180, 0, 0);
        }

        if (gameObject.tag == "Seahorse")
        {
            gameObject.transform.Rotate(-90, 0, 0);
        }
    }
}
