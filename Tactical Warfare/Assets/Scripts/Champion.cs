using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Champion 
{

    public int id;
    public string championName;
    public int cost;
   
    //tuki bi dal traite
    public Champion()
    {

    }

    public Champion(int Id, string Name, int Cost)
    {
        id = Id;
        championName = Name;
        cost = Cost;
        

    }

}
