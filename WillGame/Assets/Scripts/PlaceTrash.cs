using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTrash : MonoBehaviour
{
    public GameObject[] trashType = new GameObject[6];
    GameObject[] placeTrash = new GameObject[180];

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < placeTrash.Length; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-100, 100), Random.Range(4 + 1, 22), Random.Range(-100, 100));

            placeTrash[i] = Instantiate(trashType[Random.Range(0, 6)], pos, Quaternion.identity);
            placeTrash[i].transform.Rotate(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
