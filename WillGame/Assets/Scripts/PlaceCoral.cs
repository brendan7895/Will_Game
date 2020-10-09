using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCoral : MonoBehaviour
{
    public GameObject[] coralTypes = new GameObject[4];

    //for 1
    //public Transform[] coral;
    //public List<GameObject> corals;

    public GameObject[] coral;
    

    public LayerMask ground;
    //Vector3 pos;

    void Start()
    {
        //Gets all individual coral and places them indepentdently 1
        //coral = coralTypes[0].GetComponentsInChildren<Transform>();
        //foreach (Transform c in coral)
        //{
        //    corals.Add(c.gameObject);
        //}

        //for (int i = 0; i < corals.Count; i++)
        //{
        //    Vector3 pos = new Vector3(Random.Range(-10, 10), 4.1f, Random.Range(-10, 10));
        //    corals[i] = Instantiate(corals[i], pos, Quaternion.identity);

        //    RaycastHit hit;
        //    Ray ray = new Ray(corals[i].transform.position, Vector3.down);
        //    if (Physics.Raycast(ray, out hit, 20, ground))
        //    {
        //        Vector3 groundPos = new Vector3(
        //            corals[i].transform.position.x,
        //            hit.point.y,
        //            corals[i].transform.position.z);

        //        Debug.Log(hit.point.y);
        //        corals[i].transform.position = groundPos;
        //    }

        //}

        coral = new GameObject[30];
        for (int i = 0; i < coral.Length; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-50, 50), 4.1f, Random.Range(-50, 50));

            coral[i] = coralTypes[Random.Range(0, 4)];
            coral[i] = Instantiate(coral[i], pos, Quaternion.identity);

            RaycastHit hit;
            Ray ray = new Ray(coral[i].transform.position, Vector3.down);
            if (Physics.Raycast(ray, out hit, 20, ground))
            {
                Vector3 groundPos = new Vector3(
                    coral[i].transform.position.x,
                    hit.point.y,
                    coral[i].transform.position.z);

                Debug.Log(hit.point.y);
                coral[i].transform.position = groundPos;
            }

            if (coral[i].name.Contains("Coral4"))
            {
                coral[i].transform.Rotate(-90, 0, 0);
            }
        }


    }



    // Update is called once per frame
    void FixedUpdate()
    {
        //foreach(GameObject g in coral)
        //{
        //    // Vector3 pos;// = new Vector3(Random.Range(-50, 50), 4.1f, Random.Range(-50, 50));         

        //    RaycastHit hit = new RaycastHit();
        //    Ray ray = new Ray(g.transform.position, Vector3.down);
        //    if (Physics.Raycast(ray, out hit, 20, ground))
        //    {
        //        g.transform.Translate(g.transform.position.x, hit.point.y, g.transform.position.z);
        //    }




        //}


    }

}
