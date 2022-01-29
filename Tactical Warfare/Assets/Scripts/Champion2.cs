using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New champion", menuName ="Champion")]
public class Champion2 : ScriptableObject
{

    public int id;
    public string championName;
    public int cost;

    //tuki bi dal traite
    public void Print()
    {
        Debug.Log(championName + ": " + " Costs: " + cost);
    }

}
