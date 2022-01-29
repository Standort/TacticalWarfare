using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionDatabase : MonoBehaviour
{

    public static List<Champion> championList = new List<Champion>();

    private void Awake()
    {
        championList.Add(new Champion(15, "None", 0 ));
        championList.Add(new Champion(0, "Garen", 2));
        championList.Add(new Champion(2, "Katarina", 3));
    }
}
