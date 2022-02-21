using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Champion 
{

    public int id;
    public string championName;
    public int cost;
    public Sprite spriteImage;

  
    public Champion()
    {

    }

    public Champion(int Id, string Name, int Cost, Sprite SpriteImg  )
    {
        id = Id;
        championName = Name;
        cost = Cost;
        spriteImage = SpriteImg;


    }

}
