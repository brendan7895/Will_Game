using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCoral : MonoBehaviour
{
    public GameObject[] coralTypes = new GameObject[4];

    //for 1
    Transform[] coral;
    public List<GameObject> corals;
    GameObject[] placeCoral = new GameObject[400];

    public LayerMask ground;

    void Start()
    {
        //Gets all individual coral and places them indepentdently 1
        
        for(int i = 0; i < coralTypes.Length; i++)
        {
            
            coral = coralTypes[i].GetComponentsInChildren<Transform>();
            foreach (Transform child in coral)
            {
                if(child.gameObject.GetInstanceID() != coralTypes[i].GetInstanceID())
                {
                    corals.Add(child.gameObject);
                }
                
            }
        }     

        for (int i = 0; i < placeCoral.Length; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-100, 100), 4.1f, Random.Range(-100, 100));
            int index = Random.Range(0, corals.Count);
            placeCoral[i] = Instantiate(corals[index], pos, corals[index].transform.rotation);

            RaycastHit hit;
            Ray ray = new Ray(placeCoral[i].transform.position, Vector3.down);
            if (Physics.Raycast(ray, out hit, 20, ground))
            {
                Vector3 groundPos = new Vector3(
                    placeCoral[i].transform.position.x,
                    hit.point.y,
                    placeCoral[i].transform.position.z);

                Debug.Log(hit.point.y);
                placeCoral[i].transform.position = groundPos;
            }

        }

        //coral = new GameObject[30];
        //for (int i = 0; i < coral.Length; i++)
        //{
        //    Vector3 pos = new Vector3(Random.Range(-50, 50), 4.1f, Random.Range(-50, 50));

        //    coral[i] = coralTypes[Random.Range(0, 4)];
        //    coral[i] = Instantiate(coral[i], pos, Quaternion.identity);

        //    RaycastHit hit;
        //    Ray ray = new Ray(coral[i].transform.position, Vector3.down);
        //    if (Physics.Raycast(ray, out hit, 20, ground))
        //    {
        //        Vector3 groundPos = new Vector3(
        //            coral[i].transform.position.x,
        //            hit.point.y,
        //            coral[i].transform.position.z);

        //        Debug.Log(hit.point.y);
        //        coral[i].transform.position = groundPos;
        //    }

        //    if (coral[i].name.Contains("Coral4"))
        //    {
        //        coral[i].transform.Rotate(-90, 0, 0);
        //    }
        //}


    }

}
