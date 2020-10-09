using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCoral : MonoBehaviour
{
    public GameObject[] coralTypes = new GameObject[4];
    public static GameObject[] coral;

    //public LayerMask ground;
    //Vector3 pos;

    void Awake()
    {
        coral = new GameObject[30];      

        for(int i = 0; i < coral.Length; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-50, 50), 4.1f, Random.Range(-50, 50));
            coral[i] = coralTypes[Random.Range(0, 4)];
            coral[i] = Instantiate(coral[i], pos, Quaternion.identity);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //for (int i = 0; i < coral.Length; i++)
        //{
        //   // Vector3 pos;// = new Vector3(Random.Range(-50, 50), 4.1f, Random.Range(-50, 50));
        //    pos.x = Random.Range(-50, 50);
        //    pos.z = Random.Range(-50, 50);
        //    pos.y = 5;

        //    RaycastHit hit = new RaycastHit();
        //    Ray ray = new Ray(pos, Vector3.down);
        //    if(Physics.Raycast(ray, out hit, 20, ground))
        //    {
        //        pos.y = hit.point.y;
        //    }
            

            

        //}


    }

}
