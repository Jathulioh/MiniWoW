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
	public float respawnTimer;
	private float respawnCountdown;
	public int experienceDrop;

	public bool isMoving;

	private void Start()
	{
		agent = gameObject.GetComponent<NavMeshAgent>();
		spellBook = gameObject.GetComponentInChildren<Spellbook>();
		dropTable = gameObject.GetComponent<DropTable>();
		animationController = gameObject.GetComponentInChildren<Animator>();
	}

	private void Update()
	{
		animationController.SetBool("isMoving", isMoving);
		animationController.SetBool("isDead", isDead);

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
			isMoving = true;
		}
		if (agent.remainingDistance < minDistance)
		{
			isMoving = false;
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
			isDead = true;
			attackable = false;
			attacking = false;
			currentTarget = null;
			foreach (GameObject spell in spellBook.spells)
			{
				if (spell.name == "AutoAttack")
				{
					spell.GetComponent<AutoAttack>().TurnOff();
				}
			}
			dropTable.CalculateLoot(targetOf);
			if (targetOf.GetComponent<Player>().attacking && targetOf.GetComponent<Player>().currentTarget == this.gameObject)
			{
				targetOf.GetComponent<Player>().UpdateQuestList();
				targetOf.GetComponent<Player>().AddExperience(experienceDrop);
			}
			respawnCountdown = respawnTimer;
		}
	}

	void Respawn()
	{

	}

	void QuestHandIn(GameObject handin)
	{
		
		
		
	}

}
