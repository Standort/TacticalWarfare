using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGChampion 
{
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



   

    
    public IGChampion()
    {

    }

    public IGChampion(int Id, string Name, int Level, float AD, float AP, float AS, float MS, float Range, float AR, float MR, int HP, GameObject Model)
    {
        id = Id;
        championName = Name;
        level = Level;
        ap = AP;
        ad = AD;
        atttackseed = AS;
        ms = MS;
        range = Range;
        ar = AR;
        mr = MR;
        hp = HP;
        model = Model;


    }
}
