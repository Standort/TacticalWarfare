using UnityEngine;
using System.Collections;
/* Base class that player and enemies can derive from to include stats. */

public class CharacterStats : MonoBehaviour
{
	[SerializeField] public int team = 1; //ker team si, team 0
	// Health
	public string Name;
	public Stat maxHealth;
	[SerializeField] public float currentHealth { get; private set; }
	[SerializeField] private ManaBar _manaBar;
	[SerializeField] private HealthBar _healthBar;
	
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
	public Stat range;
	public float AttackTime;
	// Set current health to max health
	// when starting the game.

	void SetArmorToFive()
    {
		AD.baseValue = 5;
    }
	void Awake()
	{
		//print(armor.GetTrueValue() + "armor");
		
	}
    private void Start()
    {
		//_manaBar = GetComponent<ManaBar>();
		currentHealth = maxHealth.GetTrueValue();
		_healthBar.UpdateHealthBar(maxHealth.baseValue, currentHealth);
		_manaBar.UpdateManaBar(maxMana.baseValue, currentMana.baseValue);
		//StartCoroutine("DoCheck");
		StartCoroutine("DoMana");
    }
    // Damage the character
    public void TakePDamage(float damage)
	{
		// Subtract the armor value
		damage -= 	armor.GetValue();
		damage = Mathf.Clamp(damage, 0, float.MaxValue);

		// Damage the character
		currentHealth -= damage;
		Debug.Log(transform.GetChild(transform.childCount-1).name + " takes " + damage + "physcial damage.");
		print(currentHealth);
		// If health reaches zero
		_healthBar.UpdateHealthBar(maxHealth.baseValue, currentHealth);
		if (currentHealth <= 0)
		{
			Die();
		}
	}


	void Update()
	{
		//print(armor.GetTrueValue() + "armor");
		//StartCoroutine("DoCheck");
		AttackTime = AS.baseValue;
	}
	IEnumerator DoCheck()
	{
		for (; ; )
		{
			// execute block of code here
			TakePDamage(15);
			yield return new WaitForSeconds(2);
		}
	}
	IEnumerator DoMana()
    {
		for(; ; )
        {
			useMana(10);
			yield return new WaitForSeconds(2);
        }
    }
	public void TakeMDamage(float damage)
    {
		damage -= MR.GetValue();
		damage = Mathf.Clamp(damage, 0, float.MaxValue);

		// Damage the character
		currentHealth -= damage;
		Debug.Log(transform.name + " takes " + damage + "magic damage.");
		_healthBar.UpdateHealthBar(maxHealth.baseValue, currentHealth);
		// If health reaches zero
		if (currentHealth <= 0)
		{
			Die();
		}
	}
	public void useMana(float manaSpent)
    {
		
		currentMana.baseValue += manaSpent;
		if(currentMana.baseValue > maxMana.baseValue)
        {
			currentMana.baseValue = 0;
        }
		_manaBar.UpdateManaBar(maxMana.baseValue, currentMana.baseValue);
	}
	public virtual void Die()
	{
		// Die in some way
		// This method is meant to be overwritten
		//gameObject.transform.parent.GetComponent<ANIM>().Animate("Die");
		Debug.Log(transform.name + " died.");
	}
	
}