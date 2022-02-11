using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGDatabase : MonoBehaviour
{

    public static List<IGChampion> IGchampionList = new List<IGChampion>();
    //public List<IGChampion> IGchampionList2 = new List<IGChampion>();
    //public int nekaj;
    private void Awake()
    {

 
        //  public IGChampion(int Id, string Name, int Level, float AD, float AP, float AS, float MS, float Range, float AR, float MR, int HP, GameObject Model)
        IGchampionList.Add(new IGChampion(0, "Garen", 1, 5, 5, 5, 100, 125, 50, 50, 1000, Resources.Load<GameObject>("Wizard")));
        IGchampionList.Add(new IGChampion(1, "Garen1", 1, 5, 5, 5, 100, 125, 50, 50, 1000, Resources.Load<GameObject>("Wizard")));

        //championList2 = championList;
    }
}