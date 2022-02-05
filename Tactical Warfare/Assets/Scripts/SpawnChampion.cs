using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChampion : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject Champion_Prefab;
    int tempID = 0;
    string tempName;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick(GameObject ChampionIcon)
    {
        foreach(GameObject bench in  BenchMaker.BenchTiles)
        {

           // print(bench.GetComponent<BenchTileScript>().occupied);
        }
        print(ChampionIcon.GetComponent<DisplayChampion>().championName);
        spawnChampionOnBench();
        deleteIcon(ChampionIcon);
    }
    void deleteIcon(GameObject champ)
    {
        GameObject.Destroy(champ);
        tempID = champ.GetComponent<DisplayChampion>().id;
        tempName = champ.GetComponent<DisplayChampion>().championName;
        print(tempName);

    }
    void spawnChampionOnBench()
    {
        int x = BenchMaker.firstAvailable() - 1;
        //print(x);
        if(!(x==-1))
        {
            GameObject GO = Instantiate(Champion_Prefab, BenchMaker.BenchTiles[x].transform.position, Quaternion.identity);

            BenchMaker.BenchTiles[x].GetComponent<BenchTileScript>().occupied = true;

        }
        
    }
}
