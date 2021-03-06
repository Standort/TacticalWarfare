using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenchMaker : MonoBehaviour
{
    public GameObject benchTilePrefab;
    int benchWidth = 8;
    float tileOfset = 1.0f;
    public static GameObject[] BenchTiles;
    
    void Start()
    {
        BenchTiles = new GameObject[benchWidth +1];
        CreateBenchTileMap();
       
    }
   void CreateBenchTileMap()
    {
        for (int x = 0; x <= benchWidth; x++)
        {
            GameObject TempGO = Instantiate(benchTilePrefab);
            TempGO.transform.position = new Vector3(gameObject.transform.position.x + x * tileOfset, gameObject.transform.position.y , gameObject.transform.position.z );
            setTileInfo(TempGO, x);
            BenchTiles[x] = TempGO;
        }
    }
    void setTileInfo(GameObject GO, int x)
    {
        GO.transform.parent = transform;
        GO.name = x.ToString();
    }
    public static int firstAvailable()//vrne o ce je bench full ce ne index+1 prvege avalable bencha
    {
        int i = 0;
        foreach(GameObject go in BenchTiles)
        {
            
            if(go.GetComponent<BenchTileScript>().occupied == false)
            {
                
                return i+1;
            }
            i++;
        }
       
        return 0;
    }
}
