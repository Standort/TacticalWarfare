using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionPool : MonoBehaviour
{
    public List<Champion> pool = new List<Champion>();
    public List<Champion> container = new List<Champion>();
    public static List<Champion> staticPool = new List<Champion>();
    
    public static int poolSize;
    public GameObject ChampionToHand;
    public GameObject[] Clones;
    public GameObject Hand;

    
    // Start is called before the first frame update
    void Start()
    {
        staticPool = pool;
        poolSize = 8;
     
        for (int i = 0; i <  poolSize; i++)
        {
           
            pool[i] = ChampionDatabase.championList[i];
        }
       Shuffle();
        AddToHand();
       // StartCoroutine(StartGame()); //ce hoces delay
    }
    public void AddToHand()
    {
        for (int i = 0; i < 4; i++)//stevilo champov v roki
        {
           

            Instantiate(ChampionToHand, transform.position, transform.rotation);
        }
    }
    IEnumerator StartGame()
    {
        for(int i = 0; i<2; i++)//stevilo champov v roki
        {
            yield return new WaitForSeconds(0);

            Instantiate(ChampionToHand, transform.position, transform.rotation);
        }
    }
    // Update is called once per frame
    void Update()
    {
        staticPool = pool;
    }
    public void Shuffle()
    {
        Debug.Log("shuffle");
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