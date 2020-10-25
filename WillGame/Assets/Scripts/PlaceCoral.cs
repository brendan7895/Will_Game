using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlaceCoral : MonoBehaviour
{
    public GameObject[] coralTypes = new GameObject[4];

    //for 1
    Transform[] coral;
    public List<GameObject> corals;
    GameObject[] placeCoral = new GameObject[400];

    string json;

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

                //Debug.Log(hit.point.y);
                placeCoral[i].transform.position = groundPos;
            }
            
        }

        //for (int i = 0; i < placeCoral.Length; i++)
        //{
        //    json += JsonUtility.ToJson(placeCoral[i].transform.position);
        //    json += "\n";
            
        //}
        //Debug.Log(json);
        //File.WriteAllText(Application.dataPath + "/coral.json", json);
    }
}
