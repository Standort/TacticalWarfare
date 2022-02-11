using UnityEngine;

/* Base class that player and enemies can derive from to include stats. */

public class CharacterStats : MonoBehaviour
{

	// Health
	public float maxHealth = 100;
	public float currentHealth { get; private set; }

	public Stat Pdamage;
	public Stat Mdamage;
	public Stat armor;
	public Stat AD;
	public Stat AP;
	public Stat MR;
	public Stat MoveSpeed;
	public Stat AS;


	// Set current health to max health
	// when starting the game.
	void Awake()
	{
		currentHealth = maxHealth;
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

}