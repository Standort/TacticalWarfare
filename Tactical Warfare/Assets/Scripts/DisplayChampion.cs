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


    public Text nameText;
    public Text costText;
    public Image artImage;


    // Start is called before the first frame update
    void Start()
    {
        DisplayChampions.Add(ChampionDatabase.championList[displayID]);

        
    }

    // Update is called once per frame
    void Update()
    {
       
        id = DisplayChampions[0].id;
        championName = DisplayChampions[0].championName;
        cost = DisplayChampions[0].cost;
 
        spriteImage = DisplayChampions[0].spriteImage;
        nameText.text = " " + championName;
        costText.text = " " + cost;
        artImage.sprite = spriteImage;
    }
}
