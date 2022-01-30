using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class championBack : MonoBehaviour
{
    public GameObject ChampionBack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DisplayChampion.staticchampionBack == true)
        {
            ChampionBack.SetActive(true);
        }
        else
        {
            ChampionBack.SetActive(false);
        }
    }
}
