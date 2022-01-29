using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionPool : MonoBehaviour
{
    public List<Champion> pool = new List<Champion>();
    public List<Champion> container = new List<Champion>();
    
    public int poolSize;
    // Start is called before the first frame update
    void Start()
    {
        
        poolSize = ChampionDatabase.championList.Count;
        
        for (int i = 0; i <  poolSize; i++)
        {
           
            pool.Add (ChampionDatabase.championList[i]);
        }
       Shuffle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shuffle()
    {
     
        for(int i = 0; i<poolSize;i++)
        {
           
            container[0] = pool[i];
            int randomIndex = Random.Range(i, poolSize);
            pool[i] = pool[randomIndex];
            pool[randomIndex] = container[0];
        }
    }
}
//https://www.youtube.com/watch?v=5ARHzPv0vF4&list=PL4j7SP4-hFDJvQhZJn9nJb_tVzKj7dR7M&index=7 za shop refresh