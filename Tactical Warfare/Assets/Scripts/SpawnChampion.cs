using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChampion : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject Champion_Prefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        foreach(GameObject bench in  BenchMaker.BenchTiles)
        {

            print(bench.GetComponent<BenchTileScript>().occupied);
        }
        spawnChampionOnBench();

    }
    void spawnChampionOnBench()
    {
        GameObject GO = Instantiate(Champion_Prefab, BenchMaker.BenchTiles[0].transform.position, Quaternion.identity); 
        
    }
}
