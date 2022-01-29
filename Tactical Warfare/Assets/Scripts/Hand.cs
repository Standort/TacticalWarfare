using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public List<Champion> pool = new List<Champion>();
    public int x;
    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        for (int i = 0; i < 18; i++)
        {
            x = Random.Range(1, 4);
            pool[i] = ChampionDatabase.championList[x];
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
