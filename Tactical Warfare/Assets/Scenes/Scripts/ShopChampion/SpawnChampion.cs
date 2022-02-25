using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChampion : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject Champion_Prefab;
    int tempID = 0;
    string tempName;
    IGCManager igManager;
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
        tempName = ChampionIcon.GetComponent<DisplayChampion>().championName;
        spawnChampionOnBench(tempName);
        deleteIcon(ChampionIcon);
    }
    void deleteIcon(GameObject champ)
    {
        GameObject.Destroy(champ);
        tempID = champ.GetComponent<DisplayChampion>().id;
        tempName = champ.GetComponent<DisplayChampion>().championName;
       // print(tempName);

    }
    void spawnChampionOnBench(string name)
    {
        int x = BenchMaker.firstAvailable() - 1;
        //print(x);
        if(!(x==-1))
        {
            GameObject Champ = Resources.Load(name) as GameObject;
           
          
           GameObject GO2 = Instantiate(Champion_Prefab, BenchMaker.BenchTiles[x].transform.position, Quaternion.identity) as GameObject;
            var currentChampion = GO2.GetComponent<IGChampion>();
            setStats(GO2, name);
            
            currentChampion.SetName(name);
            currentChampion.SetModel(Champ);
            //var info = currentChampion.GetComponent<CharacterStats>();
            //for(int i = 0; i<IGDatabase.IGchampionList.Count;i++)
            //{
            //    if(currentChampion.ChampionName == IGDatabase.IGchampionList[i][0])
            //}
            //info.
            //currentChampion.
            GO2.GetComponent<IGChampion>().GetTile(BenchMaker.BenchTiles[x]);
            BenchMaker.BenchTiles[x].GetComponent<BenchTileScript>().occupied = true;

        }
        
    }
    void setStats(GameObject GO, string n)
    {
        var GOStats = GO.GetComponent<CharacterStats>();

       
        int ind = FindIndexWithName(n);
       
        if (ind!=0)
        {
            var Data = IGDatabase.IGList[ind - 1];
            GOStats.Name = Data.name;
            GOStats.armor.baseValue = Data.Armor;
            GOStats.AD.baseValue = Data.aD;
            GOStats.AP.baseValue = Data.aP;
            GOStats.AS.baseValue = Data.aS;
            GOStats.MR.baseValue = Data.mR;
            GOStats.maxHealth.baseValue = Data.MaxHealth;
            GOStats.maxMana.baseValue = Data.MaxMana;
            GOStats.currentMana.baseValue = Data.CurrentMana;
            GOStats.MoveSpeed.baseValue = Data.moveSpeed;
            GOStats.range.baseValue = Data.Range;
        }
        
    }
    int FindIndexWithName(string Champsname)
    {
        for(int i = 0; i < IGDatabase.IGList.Count;i++)
        {
            if (IGDatabase.IGList[i].name == Champsname)
                return i+1;
        }
        return 0;
    }
}
