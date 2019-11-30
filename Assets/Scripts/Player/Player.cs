using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
	public enum races {Human, Dwarf, NightElf, Gnome, Draenei, Worgen, Orc, Undead, Tauren, Troll, BloodElf, Goblin, Pandaren }
	public enum classes {Warrior, Paladin, Hunter, Rogue, Priest, Shaman, Mage, Warlock, Monk, Druid, DemonHunter, DeathKnight }
	public enum gender { Male, Female }
	public races characterRace;
	public classes characterClass;
	public gender characterGender;

	public GameObject hoverTarget;

	[HideInInspector] public PlayerController playerController;
	[HideInInspector] public QuestBook questBook;
	[HideInInspector] public LootFrame lootFrame;
	

	private void Start()
	{
		playerController = this.gameObject.GetComponent<PlayerController>();
		spellBook = gameObject.GetComponentInChildren<Spellbook>();
		questBook = gameObject.GetComponentInChildren<QuestBook>();
		lootFrame = GameObject.FindGameObjectWithTag("LootFrame").GetComponent<LootFrame>();
	}

	private void Update()
	{
		Targeting();
	}
	void Targeting()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out hit))
		{
			if (hit.collider.gameObject.GetComponent<Entity>() != null)
			{
				hoverTarget = hit.collider.gameObject;
				if (Input.GetMouseButtonUp(0))
				{
					currentTarget = hoverTarget;
				}
			}
			else
			{
				hoverTarget = null;
			}
		}
		
		if (currentTarget)
		{
			if (Input.GetButtonUp("Cancel"))
			{
				currentTarget = null;
			}
		}
	}

	public void UpdateQuestList()
	{
		if (currentTarget.GetComponent<Mob>().isDead)
		{
			questBook.QuestCreatureCheck(currentTarget.GetComponent<Mob>().groupID);
		}
	}

}
