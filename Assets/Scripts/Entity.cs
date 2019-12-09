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
		ExperiencePerLevel();
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

	public void RemoveTalkToMe()
	{
		Destroy(currentTalkToMe);
		currentTalkToMe = null;

	}
	public void PendingHandIn()
	{
		RemoveTalkToMe();
		currentTalkToMe = Instantiate(talktomeQuestion, Vector3.zero, transform.rotation, questGiverAttachment.transform);
		currentTalkToMe.transform.position = questGiverAttachment.transform.position;
	}
	public void PendingCompletion()
	{
		RemoveTalkToMe();
		currentTalkToMe = Instantiate(talktomeQuestionGray, Vector3.zero, transform.rotation, questGiverAttachment.transform);
		currentTalkToMe.transform.position = questGiverAttachment.transform.position;
	}

	public void AvailableQuests()
	{
		RemoveTalkToMe();
		currentTalkToMe = Instantiate(talktome, Vector3.zero, transform.rotation, questGiverAttachment.transform);
		currentTalkToMe.transform.position = questGiverAttachment.transform.position;
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
		LevelUp();
	}
	public void LevelUp()
	{
		while (experience > experienceTotal)
		{
			level++;
			experience -= experienceTotal;
			ExperiencePerLevel();
		}
	}
	public void ExperiencePerLevel()
	{
		switch (level)
		{
			case 1:
				experienceTotal = 400;
				break;
			case 2:
				experienceTotal = 900;
				break;
			case 3:
				experienceTotal = 1400;
				break;
			case 4:
				experienceTotal = 2100;
				break;
			case 5:
				experienceTotal = 2800;
				break;
			case 6:
				experienceTotal = 3800;
				break;
			case 7:
				experienceTotal = 5000;
				break;
			case 8:
				experienceTotal = 6400;
				break;
			case 9:
				experienceTotal = 8100;
				break;
			case 10:
				experienceTotal = 9240;
				break;
			case 11:
				experienceTotal = 10780;
				break;
			case 12:
				experienceTotal = 13230;
				break;
			case 13:
				experienceTotal = 16800;
				break;
			case 14:
				experienceTotal = 20380;
				break;
			case 15:
				experienceTotal = 24440;
				break;
			case 16:
				experienceTotal = 28080;
				break;
			case 17:
				experienceTotal = 31500;
				break;
			case 18:
				experienceTotal = 34800;
				break;
			case 19:
				experienceTotal = 38550;
				break;
			case 20:
				experienceTotal = 41260;
				break;
			case 21:
				experienceTotal = 400;
				break;
			case 22:
				experienceTotal = 900;
				break;
			case 23:
				experienceTotal = 1400;
				break;
			case 24:
				experienceTotal = 2100;
				break;
			case 25:
				experienceTotal = 2800;
				break;
			case 26:
				experienceTotal = 3800;
				break;
			case 27:
				experienceTotal = 5000;
				break;
			case 28:
				experienceTotal = 6400;
				break;
			case 29:
				experienceTotal = 8100;
				break;
			case 30:
				experienceTotal = 9240;
				break;
			case 31:
				experienceTotal = 400;
				break;
			case 32:
				experienceTotal = 900;
				break;
			case 33:
				experienceTotal = 1400;
				break;
			case 34:
				experienceTotal = 2100;
				break;
			case 35:
				experienceTotal = 2800;
				break;
			case 36:
				experienceTotal = 3800;
				break;
			case 37:
				experienceTotal = 5000;
				break;
			case 38:
				experienceTotal = 6400;
				break;
			case 39:
				experienceTotal = 8100;
				break;
			case 40:
				experienceTotal = 9240;
				break;
			case 41:
				experienceTotal = 400;
				break;
			case 42:
				experienceTotal = 900;
				break;
			case 43:
				experienceTotal = 1400;
				break;
			case 44:
				experienceTotal = 2100;
				break;
			case 45:
				experienceTotal = 2800;
				break;
			case 46:
				experienceTotal = 3800;
				break;
			case 47:
				experienceTotal = 5000;
				break;
			case 48:
				experienceTotal = 6400;
				break;
			case 49:
				experienceTotal = 8100;
				break;
			case 50:
				experienceTotal = 9240;
				break;
			case 51:
				experienceTotal = 400;
				break;
			case 52:
				experienceTotal = 900;
				break;
			case 53:
				experienceTotal = 1400;
				break;
			case 54:
				experienceTotal = 2100;
				break;
			case 55:
				experienceTotal = 2800;
				break;
			case 56:
				experienceTotal = 3800;
				break;
			case 57:
				experienceTotal = 5000;
				break;
			case 58:
				experienceTotal = 6400;
				break;
			case 59:
				experienceTotal = 8100;
				break;
			case 60:
				experienceTotal = 9240;
				break;
			case 61:
				experienceTotal = 400;
				break;
			case 62:
				experienceTotal = 900;
				break;
			case 63:
				experienceTotal = 1400;
				break;
			case 64:
				experienceTotal = 2100;
				break;
			case 65:
				experienceTotal = 2800;
				break;
			case 66:
				experienceTotal = 3800;
				break;
			case 67:
				experienceTotal = 5000;
				break;
			case 68:
				experienceTotal = 6400;
				break;
			case 69:
				experienceTotal = 8100;
				break;
			case 70:
				experienceTotal = 9240;
				break;
			case 71:
				experienceTotal = 400;
				break;
			case 72:
				experienceTotal = 900;
				break;
			case 73:
				experienceTotal = 1400;
				break;
			case 74:
				experienceTotal = 2100;
				break;
			case 75:
				experienceTotal = 2800;
				break;
			case 76:
				experienceTotal = 3800;
				break;
			case 77:
				experienceTotal = 5000;
				break;
			case 78:
				experienceTotal = 6400;
				break;
			case 79:
				experienceTotal = 8100;
				break;
			case 80:
				experienceTotal = 9240;
				break;
			case 81:
				experienceTotal = 400;
				break;
			case 82:
				experienceTotal = 900;
				break;
			case 83:
				experienceTotal = 1400;
				break;
			case 84:
				experienceTotal = 2100;
				break;
			case 85:
				experienceTotal = 2800;
				break;
			case 86:
				experienceTotal = 3800;
				break;
			case 87:
				experienceTotal = 5000;
				break;
			case 88:
				experienceTotal = 6400;
				break;
			case 89:
				experienceTotal = 8100;
				break;
			case 90:
				experienceTotal = 9240;
				break;
			case 91:
				experienceTotal = 400;
				break;
			case 92:
				experienceTotal = 900;
				break;
			case 93:
				experienceTotal = 1400;
				break;
			case 94:
				experienceTotal = 2100;
				break;
			case 95:
				experienceTotal = 2800;
				break;
			case 96:
				experienceTotal = 3800;
				break;
			case 97:
				experienceTotal = 5000;
				break;
			case 98:
				experienceTotal = 6400;
				break;
			case 99:
				experienceTotal = 8100;
				break;
			case 100:
				experienceTotal = 9240;
				break;
			case 101:
				experienceTotal = 400;
				break;
			case 102:
				experienceTotal = 900;
				break;
			case 103:
				experienceTotal = 1400;
				break;
			case 104:
				experienceTotal = 2100;
				break;
			case 105:
				experienceTotal = 2800;
				break;
			case 106:
				experienceTotal = 3800;
				break;
			case 107:
				experienceTotal = 5000;
				break;
			case 108:
				experienceTotal = 6400;
				break;
			case 109:
				experienceTotal = 8100;
				break;
			case 110:
				experienceTotal = 9240;
				break;
			case 111:
				experienceTotal = 400;
				break;
			case 112:
				experienceTotal = 900;
				break;
			case 113:
				experienceTotal = 1400;
				break;
			case 114:
				experienceTotal = 2100;
				break;
			case 115:
				experienceTotal = 2800;
				break;
			case 116:
				experienceTotal = 3800;
				break;
			case 117:
				experienceTotal = 5000;
				break;
			case 118:
				experienceTotal = 6400;
				break;
			case 119:
				experienceTotal = 8100;
				break;
			case 120:
				experienceTotal = 9240;
				break;

			default:
				Debug.Log("You have reached max level");
				break;
		}
	}
}