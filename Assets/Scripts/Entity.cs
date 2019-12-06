using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
	public enum sides {Alliance, Horde, Neutral};
	public enum resource {None, Mana, Energy, Rage};

	public string entityName;
	public int level;
	public int experience;
	public int experienceTotal;
	[SerializeField] int healthPoints;
	[SerializeField] int currentHealthPoints;
	[SerializeField] int attackPower;
	public float attackSpeed = 1;
	public int spellPower;

	public sides allignment;

	public GameObject currentTarget;
	public GameObject targetOf;
	public bool attackable;
	public bool attacking;
	public bool beingAttacked;
	public bool isDead;
	public bool isLootable;

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

	[Header("Quests")]
	public bool QuestGiver;

	public GameObject questGiverAttachment;
	public GameObject currentTalkToMe;

	public List<GameObject> quests;
	public List<GameObject> questHandIns;

	public GameObject talktome;
	public GameObject talktomeQuestionGray;
	public GameObject talktomeQuestion;

	void Start()
	{
		BaseHealth();
		AttackPower();
		currentHealthPoints = healthPoints;
		Quests();
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

	public void QuestHandIn(bool complete)
	{
		if (currentTalkToMe != null)
		{
			Destroy(currentTalkToMe);
		}
		if (complete == false)
		{
			currentTalkToMe = Instantiate(talktomeQuestionGray, Vector3.zero, transform.rotation, questGiverAttachment.transform);
			currentTalkToMe.transform.position = questGiverAttachment.transform.position;
		}
		else
		{
			currentTalkToMe = Instantiate(talktomeQuestion, Vector3.zero, transform.rotation, questGiverAttachment.transform);
			currentTalkToMe.transform.position = questGiverAttachment.transform.position;
		}
	}

	void Quests()
	{
		if (currentTalkToMe != null)
		{
			Destroy(currentTalkToMe);
		}
		if (quests.Count > 0)
		{
			currentTalkToMe = Instantiate(talktome, Vector3.zero, transform.rotation, questGiverAttachment.transform);
			currentTalkToMe.transform.position = questGiverAttachment.transform.position;
		}
	}

	public void Lootable()
	{
		if (this.gameObject.GetComponent<DropTable>())
		{
			isLootable = true;
		}
	}

	public void AddExperience(int exp)
	{
		experience += exp;
	}
}