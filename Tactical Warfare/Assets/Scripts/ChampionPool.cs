using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionPool : MonoBehaviour
{
    public  List<Champion> pool = new List<Champion>();
    public List<Champion> container = new List<Champion>();
    [SerializeField]
    public static List<Champion> staticPool = new List<Champion>();
    
    public static int poolSize;
    public GameObject ChampionToHand;
    public GameObject[] Clones;
    public GameObject Hand;
    public GameObject tempChampion;
    private GameObject data;
    private Champion displaychampion;

   

    // Start is called before the first frame update
    void Start() { 
    
        
        staticPool = pool;
        poolSize = 8;
  
        for (int i = 0; i <  poolSize; i++)
        {
           
            pool[i] = ChampionDatabase.championList[i];
        }
        
        Shuffle();
       AddToHand();
       //StartCoroutine(StartGame()); //ce hoces delay
    }
   
    public void AddToHand()
    {
        if(ChampionPool.poolSize >= 4)
        for (int i = 0; i < 4; i++)//stevilo champov v roki
        {
           

            Instantiate(ChampionToHand, transform.position, transform.rotation);
            
        }
        else
        {
            print("nha");
            for (int i = 0; i < ChampionPool.poolSize; i++)//stevilo champov v roki
            {


                Instantiate(ChampionToHand, transform.position, transform.rotation);

            }
        }
    }
    public void EmptyHand()
    {
        //SendBackToPool();
        foreach (Transform child in Hand.transform)
        {
            tempChampion = child.gameObject;
            // print(tempChampion.championName);//doesn't work
            DisplayChampion champname = tempChampion.GetComponent<DisplayChampion>();
            data = GameObject.FindGameObjectWithTag("Database");
            
            ChampionDatabase data2 = data.GetComponent<ChampionDatabase>();

            pool.Add(data2.championList2[champname.id]);
            poolSize++;
            GameObject.Destroy(tempChampion);//destroy works
           // print("mjav");
        }
        Shuffle();
        AddToHand();
    }
    public void SendBackToPool()
    {
            for(int i = 0; i<DisplayChampion.ShopChampions.Count;i++)
                 {
                         pool.Add(DisplayChampion.ShopChampions[i]);
            DisplayChampion.ShopChampions.RemoveAt(i);
            print("Added " + i);
                 }
           
         //   pool.Add(tempChampion);
        
          
    }
    IEnumerator StartGame()
    {
        for(int i = 0; i<2; i++)//stevilo champov v roki
        {
            yield return new WaitForSeconds(1);

            Instantiate(ChampionToHand, transform.position, transform.rotation);
        }
    }
    // Update is called once per frame
    void Update()
    {
       // SendBackToPool();
        staticPool = pool;
      
       // foreach (var x in staticPool) Debug.Log(x.championName);
    }
    public void Shuffle()
    {
        Debug.Log("shuffle");
       // DisplayChampion.Init()
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