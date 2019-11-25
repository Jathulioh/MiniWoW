using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreate : MonoBehaviour
{

	public enum races {Human, Dwarf, NightElf, Gnome, Draenei, Worgen, Orc, Undead, Tauren, Troll, BloodElf, Goblin}
	public enum classes {Warrior, Paladin, Hunter, Rogue, Priest, Shaman, Mage, Warlock, Monk, Druid, DemonHunter, DeathKnight}
	[SerializeField] private races raceList;
	[SerializeField] private classes classList;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void ClassWarrior()
	{
		classList = classes.Warrior;
	}
	public void ClassPaladin()
	{
		classList = classes.Paladin;
	}
	public void ClassHunter()
	{
		classList = classes.Hunter;
	}
	public void ClassRogue()
	{
		classList = classes.Rogue;
	}
	public void ClassPriest()
	{
		classList = classes.Priest;
	}
	public void ClassShaman()
	{
		classList = classes.Shaman;
	}
	public void ClassMage()
	{
		classList = classes.Mage;
	}
	public void ClassWarlock()
	{
		classList = classes.Warlock;
	}
	public void ClassMonk()
	{
		classList = classes.Monk;
	}
	public void ClassDruid()
	{
		classList = classes.Druid;
	}
	public void ClassDemonHunter()
	{
		classList = classes.DemonHunter;
	}
	public void ClassDeathKnight()
	{
		classList = classes.DeathKnight;
	}

	public void RaceHuman()
	{
		raceList = races.Human;
	}

	public void RaceDwarf()
	{
		raceList = races.Dwarf;
	}

	public void RaceNightElf()
	{
		raceList = races.NightElf;
	}

	public void RaceGnome()
	{
		raceList = races.Gnome;
	}

	public void RaceDraenei()
	{
		raceList = races.Draenei;
	}

	public void RaceWorgen()
	{
		raceList = races.Worgen;
	}

	public void RaceOrc()
	{
		raceList = races.Orc;
	}

	public void RaceUndead()
	{
		raceList = races.Undead;
	}

	public void RaceTauren()
	{
		raceList = races.Tauren;
	}

	public void RaceTroll()
	{
		raceList = races.Troll;
	}

	public void RaceBloodElf()
	{
		raceList = races.BloodElf;
	}

	public void RaceGoblin()
	{
		raceList = races.Goblin;
	}

}
