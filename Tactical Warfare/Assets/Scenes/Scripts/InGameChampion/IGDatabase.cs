using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGDatabase : MonoBehaviour
{
    public static List<IGStats> IGList = new List<IGStats>();



    private void Awake()
    {
        IGList.Add(new IGStats("Kayle", 10, 15, 30, 30, 1, 1.0f, 100, 30, 1000, 2 ));
        IGList.Add(new IGStats("Khione", 10, 15, 30, 30, 1, 1.0f, 100, 30,1000, 2));
        IGList.Add(new IGStats("Mengele", 10, 15, 30, 30, 1, 1.0f, 100, 30,1000,2));
        IGList.Add(new IGStats("Teresa", 10, 15, 30, 30, 1, 1.0f, 100, 30,1000,2));
    }
}
//string name;
//float Armor;
//float aD;
//float aP;
//float mR;
//float moveSpeed;
//float aS;
//float MaxMana;
//float CurrentMana;