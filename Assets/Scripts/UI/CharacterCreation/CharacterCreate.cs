using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterCreate : MonoBehaviour
{

	//public enum races {Human, Dwarf, NightElf, Gnome, Draenei, Worgen, Orc, Undead, Tauren, Troll, BloodElf, Goblin}
	//public enum classes {Warrior, Paladin, Hunter, Rogue, Priest, Shaman, Mage, Warlock, Monk, Druid, DemonHunter, DeathKnight}
	public GameObject player;
	public GameObject playerSettings;
	[SerializeField] private Player.races raceList;
	[SerializeField] private Player.classes classList;

	//Starting Equipment
	public GameObject WarriorEquipment;
	public GameObject PaladinEquipment;
	public GameObject MageEquipment;
	public Equipment head = null;
	public Equipment neck = null;
	public Equipment shoulder = null;
	public Equipment back = null;
	public Equipment chest = null;
	public Equipment shirt = null;
	public Equipment tabard = null;
	public Equipment wrist = null;
	public Equipment hands = null;
	public Equipment waist = null;
	public Equipment legs = null;
	public Equipment feet = null;
	public Equipment ring1 = null;
	public Equipment ring2 = null;
	public Equipment trinket1 = null;
	public Equipment trinket2 = null;
	public Equipment mainhand = null;
	public Equipment offhand = null;

	private bool enterWorld;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void Equipment(Player.classes currentClass)
	{
		EquipmentSet settings = null;
		CharacterAppearance ca = player.GetComponent<CharacterAppearance>();
		if (currentClass == Player.classes.Warrior)
		{
			settings = WarriorEquipment.GetComponent<EquipmentSet>();
			goto ClassSettings;
		}
		else if (currentClass == Player.classes.Paladin)
		{
			settings = PaladinEquipment.GetComponent<EquipmentSet>();
			goto ClassSettings;
		}
		else if (currentClass == Player.classes.Mage)
		{
			settings = MageEquipment.GetComponent<EquipmentSet>();
			goto ClassSettings;
		}
		else return;
		ClassSettings:
		if (settings.head != ca.head)
			ca.head = settings.head;
			head = settings.head;
		if (settings.shoulder != ca.shoulder)
			ca.shoulder = settings.shoulder;
			shoulder = settings.shoulder;
		if (settings.back != ca.back)
			ca.back = settings.back;
			back = settings.back;
		if (settings.chest != ca.chest)
			ca.chest = settings.chest;
			chest = settings.chest;
		if (settings.shirt != ca.shirt)
			ca.shirt = settings.shirt;
			shirt = settings.shirt;
		if (settings.tabard != ca.tabard)
			ca.tabard = settings.tabard;
			tabard = settings.tabard;
		if (settings.wrist != ca.wrist)
			ca.wrist = settings.wrist;
			wrist = settings.wrist;
		if (settings.hands != ca.hands)
			ca.hands = settings.hands;
			hands = settings.hands;
		if (settings.waist != ca.waist)
			ca.waist = settings.waist;
			waist = settings.waist;
		if (settings.legs != ca.legs)
			ca.legs = settings.legs;
			legs = settings.legs;
		if (settings.feet != ca.feet)
			ca.feet = settings.feet;
			feet = settings.feet;
		if (settings.mainhand != ca.mainhand)
			ca.mainhand = settings.mainhand;
			mainhand = settings.mainhand;
		if (settings.offhand != ca.offhand)
			ca.offhand = settings.offhand;
			offhand = settings.offhand;

	}

	public void EnterWorld()
	{

		playerSettings.GetComponent<PlayerSettings>().characterClass = classList;
		playerSettings.GetComponent<PlayerSettings>().head = head;
		playerSettings.GetComponent<PlayerSettings>().neck = neck;
		playerSettings.GetComponent<PlayerSettings>().shoulder = shoulder;
		playerSettings.GetComponent<PlayerSettings>().back = back;
		playerSettings.GetComponent<PlayerSettings>().chest = chest;
		playerSettings.GetComponent<PlayerSettings>().shirt = shirt;
		playerSettings.GetComponent<PlayerSettings>().tabard = tabard;
		playerSettings.GetComponent<PlayerSettings>().wrist = wrist;
		playerSettings.GetComponent<PlayerSettings>().hands = hands;
		playerSettings.GetComponent<PlayerSettings>().waist = waist;
		playerSettings.GetComponent<PlayerSettings>().legs = legs;
		playerSettings.GetComponent<PlayerSettings>().feet = feet;
		playerSettings.GetComponent<PlayerSettings>().ring1 = ring1;
		playerSettings.GetComponent<PlayerSettings>().ring2 = ring2;
		playerSettings.GetComponent<PlayerSettings>().trinket1 = trinket1;
		playerSettings.GetComponent<PlayerSettings>().trinket2 = trinket2;
		playerSettings.GetComponent<PlayerSettings>().mainhand = mainhand;
		playerSettings.GetComponent<PlayerSettings>().offhand = offhand;
		if (enterWorld == false) {
			enterWorld = true;
		SceneManager.LoadScene(1);
		}
	}

	public void ClassWarrior()
	{
		classList = Player.classes.Warrior;
		Equipment(classList);
	}
	public void ClassPaladin()
	{
		classList = Player.classes.Paladin;
		Equipment(classList);
	}
	public void ClassHunter()
	{
		classList = Player.classes.Hunter;
	}
	public void ClassRogue()
	{
		classList = Player.classes.Rogue;
	}
	public void ClassPriest()
	{
		classList = Player.classes.Priest;
	}
	public void ClassShaman()
	{
		classList = Player.classes.Shaman;
	}
	public void ClassMage()
	{
		classList = Player.classes.Mage;
		Equipment(classList);
	}
	public void ClassWarlock()
	{
		classList = Player.classes.Warlock;
	}
	public void ClassMonk()
	{
		classList = Player.classes.Monk;
	}
	public void ClassDruid()
	{
		classList = Player.classes.Druid;
	}
	public void ClassDemonHunter()
	{
		classList = Player.classes.DemonHunter;
	}
	public void ClassDeathKnight()
	{
		classList = Player.classes.DeathKnight;
	}

	public void RaceHuman()
	{
		raceList = Player.races.Human;
	}

	public void RaceDwarf()
	{
		raceList = Player.races.Dwarf;
	}

	public void RaceNightElf()
	{
		raceList = Player.races.NightElf;
	}

	public void RaceGnome()
	{
		raceList = Player.races.Gnome;
	}

	public void RaceDraenei()
	{
		raceList = Player.races.Draenei;
	}

	public void RaceWorgen()
	{
		raceList = Player.races.Worgen;
	}

	public void RaceOrc()
	{
		raceList = Player.races.Orc;
	}

	public void RaceUndead()
	{
		raceList = Player.races.Undead;
	}

	public void RaceTauren()
	{
		raceList = Player.races.Tauren;
	}

	public void RaceTroll()
	{
		raceList = Player.races.Troll;
	}

	public void RaceBloodElf()
	{
		raceList = Player.races.BloodElf;
	}

	public void RaceGoblin()
	{
		raceList = Player.races.Goblin;
	}

}
