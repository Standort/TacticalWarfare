using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIleMapGenerator : MonoBehaviour
{
    public GameObject tilePrefab;
    int mapWidth=8, mapHeight=5;
    
    float tileOfset = 1.0f;
    void Start()
    {
        CreateQuadTileMap();
    }
    void CreateQuadTileMap()
    {
        
        for(int x = 0; x <= mapWidth; x++)
        {
            for(int z = 0;  z<= mapHeight; z++)
            {

                
                GameObject TempGO = Instantiate(tilePrefab);
                TempGO.transform.position = new Vector3(gameObject.transform.position.x +x * tileOfset, gameObject.transform.position.y+ 0, gameObject.transform.position.z + z * tileOfset);

                setTileInfo(TempGO, x, z);
            }
        }
    }
   
    void setTileInfo(GameObject GO, int x, int z)
    {
        GO.transform.parent = transform;
        GO.name = x.ToString() + ", " + z.ToString();
    }
}
