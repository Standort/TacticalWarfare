using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class DisplayChampion : MonoBehaviour
{
    //14. april oddaj
    public List<Champion> DisplayChampions = new List<Champion>();
    public List<Champion> ShopChampions = new List<Champion>();
    public int[] champID;
    public int displayID;
    public int id;
    public string championName;
    public int cost;
    public Sprite spriteImage;
    public bool championBack;
    public static bool staticchampionBack;
    public bool y;
    public Text nameText;
    public Text costText;
    public Image artImage;

    public GameObject Hand;
    public int numberOfChampionsInPool;
    // Start is called before the first frame update
    
    void Start()
    {

        numberOfChampionsInPool = ChampionPool.poolSize;
        DisplayChampions[0]= ChampionDatabase.championList[displayID];



    }

    // Update is called once per frame
    void Update()
    {
        //   displayID = DisplayChampions[0].

        //  print(displayID);
        numberOfChampionsInPool = ChampionPool.poolSize;
        id = DisplayChampions[0].id;
        championName = DisplayChampions[0].championName;
        cost = DisplayChampions[0].cost;

        spriteImage = DisplayChampions[0].spriteImage;
        nameText.text = " " + championName;
        costText.text = " " + cost;
        artImage.sprite = spriteImage;


        Hand = GameObject.Find("Hand");
        
        if(this.transform.parent == Hand.transform.parent)
        {
            championBack = false;
        }
        staticchampionBack = championBack;
        if(this.tag == "Clone" )//&& numberOfChampionsInPool != 0)
        {

            //print(ChampionPool.poolSize);
            DisplayChampions[0] = ChampionPool.staticPool[numberOfChampionsInPool - 1]; //tuki je koda za shop percentage 
            ShopChampions[0] = ChampionPool.staticPool[numberOfChampionsInPool - 1];
           
            ChampionPool.staticPool.RemoveAt(numberOfChampionsInPool - 1);
            //ChampionPool.staticPool[numberOfChampionsInPool - 1] = ChampionDatabase.championList[numberOfChampionsInPool - 1];
            print(ShopChampions[0].cost);
            //numberOfChampionsInPool -= 1;
            ChampionPool.poolSize -= 1;
          
            championBack = false;
            this.tag = "Untagged";
        }
       
       
    }
    public void Refresh(int xx)
    {
      
        
         //  print(ShopChampions.Count);
            for(int i = 0; i< xx;i++)
            {

                ChampionPool.staticPool.Add(ShopChampions[i]);
               print(ShopChampions[i].championName);
                ShopChampions.RemoveAt(i);
            }
           
         
            //ChampionPool.staticPool[numberOfChampionsInPool - 1]= ShopChampions[0];
        
        
    }
}
