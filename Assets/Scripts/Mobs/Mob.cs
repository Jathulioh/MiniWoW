using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mob : Entity
{

	public enum strengthClass {Normal, Rare, Elite, RareElite}
	public enum react {Hostile, Neutral, Friendly}

	public NavMeshAgent agent;
	private DropTable dropTable;

	public react reactHorde;
	public react reactAlliance;

	[Header("Creature Info")]

	public int groupID;
	public strengthClass rarity;
	public float aggroRadius;


	private void Start()
	{
		agent = gameObject.GetComponent<NavMeshAgent>();
		spellBook = gameObject.GetComponentInChildren<Spellbook>();
		dropTable = gameObject.GetComponent<DropTable>();
	}

	private void Update()
	{

		

		if (BeingAttacked() && !isDead)
		{
			Combat();
			MoveTo(currentTarget.transform.position, 2.5f);
			Death();
		}
	}

	public void MoveTo(Vector3 target, float minDistance)
	{
		if (Vector3.Distance(gameObject.transform.position, target) > minDistance)
		{
			agent.stoppingDistance = minDistance;
			agent.SetDestination(target);
		}
	}

	public bool BeingAttacked()
	{
		if (targetOf != null)
		{
			if (targetOf.GetComponent<Entity>().attacking && targetOf.GetComponent<Entity>().currentTarget == this.gameObject)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else
		{
			return false;
		}
	}

	void Combat()
	{

		currentTarget = targetOf;
		foreach (GameObject spell in spellBook.spells)
			{
				if (spell.name == "AutoAttack")
				{
					spell.GetComponent<AutoAttack>().TurnOn();
				}
			}
		
	}

	void DistanceCheck()
	{
		
	}

	void Death()
	{
		if (GetCurrentHealth() <= 0)
		{
			Debug.Log("Died");
			isDead = true;
			attacking = false;
			dropTable.CalculateLoot();
			if (targetOf.GetComponent<Player>().attacking && targetOf.GetComponent<Player>().currentTarget == this.gameObject)
			{
				targetOf.GetComponent<Player>().UpdateQuestList();
			}
		}
	}

}
