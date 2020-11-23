using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceJellyfish : MonoBehaviour
{
    public GameObject jellyfish;
    GameObject[] jellyfishArr = new GameObject[50];

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < jellyfishArr.Length; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-100, 100), Random.Range(4 + 1, 22), Random.Range(-100, 100));

            jellyfishArr[i] = Instantiate(jellyfish, pos, Quaternion.identity);
            jellyfishArr[i].transform.Rotate(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
