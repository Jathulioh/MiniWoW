using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : Entity
{

	public enum react { Hostile, Neutral, Friendly }

	public NavMeshAgent agent;

	public react reactHorde;
	public react reactAlliance;

	void QuestCheck()
	{

	}

}
