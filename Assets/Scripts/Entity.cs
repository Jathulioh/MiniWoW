using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
	public enum sides {Alliance, Horde, Neutral};
	public enum resource {None, Mana, Energy, Rage};

	public string entityName;
	public int level;
	[SerializeField] int healthPoints;
	[SerializeField] int currentHealthPoints;
	[SerializeField] int attackPower;
	public float attackSpeed = 1;
	public int spellPower;

	public sides allignment;

	public GameObject currentTarget;
	public GameObject targetOf;
	public bool attacking;
	public bool beingAttacked;

	[HideInInspector] public Spellbook spellBook;

	[Header("Primary")]
	[Header("Attributes")]
	//Stats
	//Primary Attributes
	public int stamina;
	public int strength;
	public int agility;
	public int intellect;
	[Header("Secondary")]
	//Secondary Attributes
	public int crit;
	public int haste;
	public int mastery;
		//multistrike
	public int versatility;
	public int bonusArmour;
	public int spirit;

	void Start()
	{
		BaseHealth();
		AttackPower();
		currentHealthPoints = healthPoints;
	}

	public virtual void BaseHealth()
	{
		healthPoints = stamina * 20;
	}

	public int GetTotalHealth()
	{
		return healthPoints;
	}

	public int GetCurrentHealth()
	{
		return currentHealthPoints;
	}

	public int GetAttackPower()
	{
		return attackPower;
	}

	public float GetAttackSpeed()
	{
		return attackSpeed;
	}

	public void TakeDamage(int Damage, GameObject Attacker)
	{
		currentHealthPoints -= Damage;
		targetOf = Attacker;
	}

	public void AttackPower()
	{
		attackPower = (level * 3) + (strength * 2 - 20);
	}

}
