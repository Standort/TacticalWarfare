using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionToHand : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Hand;
    public GameObject HandChampion;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Hand = GameObject.Find("Hand");
        HandChampion.transform.SetParent(Hand.transform);
        HandChampion.transform.localScale = Vector3.one;
        HandChampion.transform.position = new Vector3(transform.position.x, transform.position.y, -40);
        HandChampion.transform.eulerAngles = new Vector3(25, 0, 0);
    }
}
