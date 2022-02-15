using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGDatabase : MonoBehaviour
{
    public static List<CharacterStats> IGchampionList = new List<CharacterStats>();
    private void Awake()
    {
      //  IGchampionList.Add(new CharacterStats("Kayle",  10, 20, 30, 10, 100, 1.0f, 100, 20));

    }
}
//Name = name;
//armor = Armor;
//AD = aD;
//AP = aP;
//MR = mR;
//MoveSpeed = moveSpeed;
//AS = aS;
//maxMana = MaxMana;
//currentMana = CurrentMana;