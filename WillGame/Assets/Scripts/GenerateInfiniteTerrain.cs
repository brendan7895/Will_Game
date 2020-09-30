using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Tile
{
    public GameObject tile;
    public float creationTime;

    public Tile(GameObject t, float ct)
    {
        tile = t;
        creationTime = ct;
    }
}
public class GenerateInfiniteTerrain : MonoBehaviour
{
    public GameObject plane;
    public GameObject player;

    int planeSize = 10;
    int halfTileX = 10;
    int halfTileZ = 10;

    Vector3 startPos;

    Hashtable tiles = new Hashtable();

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.fogColor = Camera.main.backgroundColor;
        RenderSettings.fogDensity = 0.02f;
        RenderSettings.fog = true;

        this.gameObject.transform.position = Vector3.zero;
        startPos = Vector3.zero;

        float updateTime = Time.realtimeSinceStartup;

        for(int x = -halfTileX; x < halfTileX; x++)
        {
            for(int z = -halfTileZ; z < halfTileZ; z++)
            {
                Vector3 pos = new Vector3((x * planeSize + startPos.x), 0, (z * planeSize + startPos.z));

                GameObject t = Instantiate(plane, pos, Quaternion.identity);

                string tileName = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                t.name = tileName;
                Tile tile = new Tile(t, updateTime);
                tiles.Add(tileName, tile);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //find how far the players moved since terrain update
        int xMove = (int)(player.transform.position.x - startPos.x);
        int zMove = (int)(player.transform.position.z - startPos.z);

        if(Mathf.Abs(xMove) >= planeSize || Mathf.Abs(zMove) >= planeSize)
        {
            float updateTime = Time.realtimeSinceStartup;

            //round to nearest tile size
            int playerX = (int)(Mathf.Floor(player.transform.position.x / planeSize) * planeSize);
            int playerZ = (int)(Mathf.Floor(player.transform.position.z / planeSize) * planeSize);

            for (int x = -halfTileX; x < halfTileX; x++)
            {
                for (int z = -halfTileZ; z < halfTileZ; z++)
                {
                    Vector3 pos = new Vector3((x * planeSize + playerX), 0, (z * planeSize + playerZ));

                    string tileName = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();

                    if (!tiles.ContainsKey(tileName))
                    {
                        GameObject t = Instantiate(plane, pos, Quaternion.identity);
                        t.name = tileName;
                        Tile tile = new Tile(t, updateTime);
                        tiles.Add(tileName, tile);
                    }
                    else
                    {
                        (tiles[tileName] as Tile).creationTime = updateTime;
                    }
                }
            }

            //destroying tiles not just placed or with new updated time
            //placing new tiles in the hastable
            Hashtable newTerrain = new Hashtable();

            foreach(Tile t in tiles.Values)
            {
                if (t.creationTime != updateTime)
                {
                    Destroy(t.tile);
                }
                else
                {
                    newTerrain.Add(t.tile.name, t);
                }
            }
            //place new hashtable into the current one
            tiles = newTerrain;
            startPos = player.transform.position;
        }
    }
}
