using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionDatabase : MonoBehaviour
{

    public static List<Champion> championList = new List<Champion>();

    private void Awake()
    {
        
        championList.Add(new Champion(0, "Garen",1, Resources.Load<Sprite>("Garen")));
        championList.Add(new Champion(1, "Katarina", 2, Resources.Load<Sprite>("Katarina")));
        championList.Add(new Champion(2, "Olaf", 5, Resources.Load<Sprite>("Olaf")));
        championList.Add(new Champion(3, "Elise", 3, Resources.Load<Sprite>("Elise")));
    }
}
