using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGCManager : MonoBehaviour
{
   
    public  List<GameObject> ChampionOnBoard = new List<GameObject>();
    public void AddToList(GameObject GO)
    {
        ChampionOnBoard.Add(GO);
    }
    public void RemoveFromList(string name)
    {
        int i = 0;
        foreach(var x in ChampionOnBoard)
        {
            int y = x.transform.childCount -1;
            if(x.transform.GetChild(y).GetComponent<CharacterStats>().Name == name )
            {
                ChampionOnBoard.RemoveAt(i);
            }
            i++;
        }
    }
}
