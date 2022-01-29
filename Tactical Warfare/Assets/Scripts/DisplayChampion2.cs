using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class DisplayChampion2 : MonoBehaviour
{

    public Champion2 champion;


    

    public Text nameText;
    public Text costText;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = champion.championName;
        costText.text = champion.cost.ToString();
    }

  
}
