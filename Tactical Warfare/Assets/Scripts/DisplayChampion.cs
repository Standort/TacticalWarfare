using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class DisplayChampion : MonoBehaviour
{
    //14. april oddaj
    public List<Champion> DisplayChampions = new List<Champion>();
    public static List<Champion> ShopChampions = new List<Champion>();
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
    
    public void Start()
    {

        Init();
    }
    public void Init()
    {
        numberOfChampionsInPool = ChampionPool.poolSize;
        DisplayChampions[0] = ChampionDatabase.championList[displayID];


       
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
            ShopChampions.Add(ChampionPool.staticPool[numberOfChampionsInPool - 1]);
           
            ChampionPool.staticPool.RemoveAt(numberOfChampionsInPool - 1);
            //ChampionPool.staticPool[numberOfChampionsInPool - 1] = ChampionDatabase.championList[numberOfChampionsInPool - 1];
          
            //numberOfChampionsInPool -= 1;
            ChampionPool.poolSize -= 1;
          
            championBack = false;
            this.tag = "Untagged";
            print(ChampionPool.poolSize);
        }
       
       
    }
    public void turnBlack()
    {
        championBack = !championBack ;
    }
    public void onChampionClick()
    {

    }
}
