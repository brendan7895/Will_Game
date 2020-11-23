using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlaceCoral : MonoBehaviour
{
    public GameObject[] coralTypes = new GameObject[4];
    public GameObject[] fishType = new GameObject[2];

    //for 1
    Transform[] coral;
    public List<GameObject> corals;
    GameObject[] placeCoral = new GameObject[400];

    Transform[] fish;
    public List<GameObject> fishList;
    GameObject[] placeFish = new GameObject[350];

    public LayerMask ground;
    Vector3 groundPos;

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
                groundPos = new Vector3(
                    placeCoral[i].transform.position.x,
                    hit.point.y,
                    placeCoral[i].transform.position.z);

                //Debug.Log(hit.point.y);
                placeCoral[i].transform.position = groundPos;
            }
            
        }

        for (int i = 0; i < fishType.Length; i++)
        {

            fish = fishType[i].GetComponentsInChildren<Transform>();
            foreach (Transform child in fish)
            {
                if (child.gameObject.GetInstanceID() != fishType[i].GetInstanceID())
                {
                    fishList.Add(child.gameObject);
                }

            }
        }

        for (int i = 0; i < placeFish.Length; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-200, 200), Random.Range(groundPos.y+1, 15), Random.Range(-200, 200));
            int index = Random.Range(0, fishList.Count);
            
            placeFish[i] = Instantiate(fishList[index], pos, Quaternion.identity);
            placeFish[i].transform.Rotate(-90, Random.Range(0, 360), 90);

            if(placeFish[i].tag == "Fish2")
            {
                Vector3 scale = new Vector3(0.1f, 0.1f, 0.1f);
                placeFish[i].transform.localScale = scale;
            }

        }

    }
}
