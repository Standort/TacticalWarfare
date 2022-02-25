using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGStats 
{

		public string name;
	public float Armor;
	public float aD;
	public float aP;
	public float mR;
	public float moveSpeed;
	public float aS;
	public float MaxMana;
	public float CurrentMana;
	public float MaxHealth;
	public float Range;
	public IGStats(string Name, float armor, float AD, float AP, float MR, float MoveSpeed, float AS, float maxMana, float currentMana, float maxHealth, float range)
    {
		name = Name;
		Armor = armor;
		aD = AD;
		aP = AP;
		mR = MR;
		moveSpeed = MoveSpeed;
		aS = AS;
		MaxMana = maxMana;
		CurrentMana = currentMana;
		MaxHealth = maxHealth;
		Range = range;
    }
	
}
