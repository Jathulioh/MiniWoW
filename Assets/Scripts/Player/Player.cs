using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
	public enum races {Human, Dwarf, NightElf, Gnome, Draenei, Worgen, Orc, Undead, Tauren, Troll, BloodElf, Goblin, Pandaren }
	public enum classes {Warrior, Paladin, Hunter, Rogue, Priest, Shaman, Mage, Warlock, Monk, Druid, DemonHunter, DeathKnight }
	public enum gender { Male, Female }
	[Header("Customization")]
	public races characterRace;
	public classes characterClass;
	public gender characterGender;

	[Header("Player Specific Vars")]
	public GameObject hoverTarget;

	[HideInInspector] public PlayerController playerController;
	[HideInInspector] public QuestBook questBook;
	[HideInInspector] public Inventory inventory;
	[HideInInspector] public LootFrame lootFrame;
	[HideInInspector] public AcceptQuest questFrame;
	[HideInInspector] public GameMenu gameMenu;
	private bool gameMenuActive = false;

	private void Awake()
	{
		playerController = this.gameObject.GetComponent<PlayerController>();
		if (playerController.enabled)
		{
			spellBook = gameObject.GetComponentInChildren<Spellbook>();
			questBook = gameObject.GetComponentInChildren<QuestBook>();
			inventory = gameObject.GetComponent<Inventory>();
			lootFrame = GameObject.FindGameObjectWithTag("LootFrame").GetComponent<LootFrame>();
			questFrame = GameObject.FindGameObjectWithTag("QuestFrame").GetComponent<AcceptQuest>();
			gameMenu = GameObject.FindGameObjectWithTag("GameMenu").GetComponent<GameMenu>();
			gameMenu.gameObject.SetActive(false);

		}
	}

	private void Update()
	{
		if (Input.GetButtonUp("Cancel"))
			OpenGameMenu();
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

	public void OpenGameMenu()
	{
		
			if (gameMenuActive == false)
			{
				if (currentTarget == null)
				{
					gameMenuActive = true;
					gameMenu.gameObject.SetActive(true);
				}
			}
			else
			{
				gameMenuActive = false;
				gameMenu.gameObject.SetActive(false);
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
