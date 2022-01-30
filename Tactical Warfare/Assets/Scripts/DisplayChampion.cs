using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class DisplayChampion : MonoBehaviour
{

    public List<Champion> DisplayChampions = new List<Champion>();
    public int displayID;
    public int id;
    public string championName;
    public int cost;
    public Sprite spriteImage;
    public bool championBack;
    public static bool staticchampionBack;

    public Text nameText;
    public Text costText;
    public Image artImage;

    public GameObject Hand;
    public int numberOfChampionsInPool;
    // Start is called before the first frame update
    void Start()
    {
        
        
        DisplayChampions.Add(ChampionDatabase.championList[displayID]);

       
        id = DisplayChampions[0].id;
        championName = DisplayChampions[0].championName;
        cost = DisplayChampions[0].cost;

        spriteImage = DisplayChampions[0].spriteImage;
        nameText.text = " " + championName;
        costText.text = " " + cost;
        artImage.sprite = spriteImage;

        numberOfChampionsInPool = ChampionPool.poolSize;
    }

    // Update is called once per frame
    void Update()
    {
        Hand = GameObject.Find("Hand");
        
        if(this.transform.parent == Hand.transform.parent)
        {
            championBack = false;
        }
        staticchampionBack = championBack;
        if(this.tag == "Clone" && numberOfChampionsInPool != 0)
        {
            
            DisplayChampions.Add(ChampionPool.staticPool[numberOfChampionsInPool - 1]);
            numberOfChampionsInPool -= 1;
            ChampionPool.poolSize -= 1;
            championBack = false;
            this.tag = "Untagged";
        }
    }
}
