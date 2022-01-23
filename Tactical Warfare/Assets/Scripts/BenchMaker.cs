using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenchMaker : MonoBehaviour
{
    public GameObject benchTilePrefab;
    int benchWidth = 8;
    float tileOfset = 1.0f;
    void Start()
    {
        CreateBenchTileMap();
    }
   void CreateBenchTileMap()
    {
        for (int x = 0; x <= benchWidth; x++)
        {
            GameObject TempGO = Instantiate(benchTilePrefab);
            TempGO.transform.position = new Vector3(gameObject.transform.position.x + x * tileOfset, gameObject.transform.position.y , gameObject.transform.position.z );
            setTileInfo(TempGO, x);
        }
    }
    void setTileInfo(GameObject GO, int x)
    {
        GO.transform.parent = transform;
        GO.name = x.ToString();
    }
}
