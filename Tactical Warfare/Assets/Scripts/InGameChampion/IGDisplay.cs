using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGDisplay : MonoBehaviour
{
    [SerializeField]
    public List<IGChampion> IGDisplayChampions = new List<IGChampion>();
    // Start is called before the first frame update
    public int id;
    public string championName;
    public int level;
    public float ap;
    public float ad;
    public float atttackseed;
    public float ms;
    public float range;
    public float ar;
    public float mr;
    public int hp;
    public GameObject model;

    public void Start()
    {

        Init();
    }
    public void Init()
    {
       
        IGDisplayChampions.Add
          ( IGDatabase.IGchampionList[id]);


    }
    public void Update()
    {
        id = IGDisplayChampions[0].id;
        championName = IGDisplayChampions[0].championName;
        level = IGDisplayChampions[0].level;
        ap = IGDisplayChampions[0].ap;
        ad = IGDisplayChampions[0].ad;
        atttackseed = IGDisplayChampions[0].atttackseed;
        ms = IGDisplayChampions[0].ms;
        range = IGDisplayChampions[0].range;
        ar = IGDisplayChampions[0].ar;
        mr = IGDisplayChampions[0].mr;
        hp = IGDisplayChampions[0].hp;
        model = IGDisplayChampions[0].model;
    }
}
