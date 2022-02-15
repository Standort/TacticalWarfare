using UnityEngine;
using System.Collections;
/* Base class that player and enemies can derive from to include stats. */

public class CharacterStats : MonoBehaviour
{

	// Health
	public Stat maxHealth;
	[SerializeField] public float currentHealth { get; private set; }

	 Stat Pdamage;
	 Stat Mdamage;
	public Stat armor;
	public Stat AD;
	public Stat AP;
	public Stat MR;
	public Stat MoveSpeed;
	public Stat AS;
	public Stat maxMana;
	public Stat currentMana;
	
	// Set current health to max health
	// when starting the game.
	void Awake()
	{
		currentHealth = maxHealth.GetTrueValue();
	}
    private void Start()
    {
		StartCoroutine("DoCheck");
    }
    // Damage the character
    public void TakePDamage(float damage)
	{
		// Subtract the armor value
		damage -= 	armor.GetValue();
		damage = Mathf.Clamp(damage, 0, float.MaxValue);

		// Damage the character
		currentHealth -= damage;
		Debug.Log(transform.name + " takes " + damage + "physcial damage.");

		// If health reaches zero
		if (currentHealth <= 0)
		{
			Die();
		}
	}


	void Update()
	{
		//StartCoroutine("DoCheck");
	}
	IEnumerator DoCheck()
	{
		for (; ; )
		{
			// execute block of code here
			TakePDamage(1);
			yield return new WaitForSeconds(10);
		}
	}
	public void TakeMDamage(float damage)
    {
		damage -= MR.GetValue();
		damage = Mathf.Clamp(damage, 0, float.MaxValue);

		// Damage the character
		currentHealth -= damage;
		Debug.Log(transform.name + " takes " + damage + "magic damage.");

		// If health reaches zero
		if (currentHealth <= 0)
		{
			Die();
		}
	}

	public virtual void Die()
	{
		// Die in some way
		// This method is meant to be overwritten
		Debug.Log(transform.name + " died.");
	}
	public CharacterStats(
	 Stat Armor,
	 Stat aD,
	 Stat aP,
	 Stat mR,
	 Stat moveSpeed,
	 Stat aS,
	 Stat MaxMana,
	 Stat CurrentMana)
    {
		armor = Armor;
		AD = aD;
		AP = aP;
		MR = mR;
		MoveSpeed = moveSpeed;
		AS = aS;
		maxMana = MaxMana;
		currentMana = CurrentMana;
    }
}