using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionDatabase : MonoBehaviour
{

    public static List<Champion> championList = new List<Champion>();
    public List<Champion> championList2 = new List<Champion>();
    public int nekaj;
    private void Awake()
    {
        
        championList.Add(new Champion(0, "Teresa", 1, Resources.Load<Sprite>("Garen")));
        championList.Add(new Champion(1, "Mengele", 2, Resources.Load<Sprite>("Katarina")));
        championList.Add(new Champion(2, "Kayle", 5, Resources.Load<Sprite>("Olaf")));
        championList.Add(new Champion(3, "Khione", 3, Resources.Load<Sprite>("Elise")));


        championList.Add(new Champion(4, "Teresa", 1, Resources.Load<Sprite>("Garen")));
        championList.Add(new Champion(5, "Mengele", 2, Resources.Load<Sprite>("Katarina")));
        championList.Add(new Champion(6, "Kayle", 5, Resources.Load<Sprite>("Olaf")));
        championList.Add(new Champion(7, "Khione", 3, Resources.Load<Sprite>("Elise")));




        championList2 = championList;
    }
}
