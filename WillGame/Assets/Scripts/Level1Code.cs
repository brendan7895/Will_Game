using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Code : MonoBehaviour
{
    public GameObject parent;
    public GameObject particle;

    GameObject g;
    
    // Start is called before the first frame update
    void Start()
    {
        particle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo = new RaycastHit();
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse is down");

            
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, LayerMask.GetMask("boulder"));
            if (hit)
            {
                Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.tag == "Boulder")
                {
                    Debug.Log("It's working!");
                    hitInfo.transform.SetParent(parent.transform);
                    if (hitInfo.transform.name == "GeoSphere003 (17)")
                    {
                        particle.SetActive(true);
                    }
                }
                else
                {
                    Debug.Log("nopz");
                }
            }
            else
            {
                Debug.Log("No hit");
            }
            Debug.Log("Mouse is down");
        }

        if (Input.GetMouseButtonDown(1))
        {
            //hitInfo.transform.SetParent(null);
            
            parent.transform.DetachChildren();
        }
    }

    //void OnTriggerEnter(Collider col)
    //{
    //    if (col.tag == "Boulder")
    //    {
    //        col.transform.SetParent(gameObject.transform);
    //    }
    //}
}
