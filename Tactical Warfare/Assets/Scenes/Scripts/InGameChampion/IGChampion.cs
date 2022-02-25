using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IGChampion : MonoBehaviour
{
    public  string ChampionName;
    public  GameObject Model;
    public GameObject CurrentTile;
    public  void SetName(string name)
    {
        ChampionName = name;
    }
    public void SetModel(GameObject model)
    {
        Model = model;
    }
    private void Start()
    {
        var ch = Instantiate(Model, gameObject.transform);
        ch.transform.parent = transform;
    }
    public void GetTile(GameObject tile)
    {
        CurrentTile = tile;
    }
}
