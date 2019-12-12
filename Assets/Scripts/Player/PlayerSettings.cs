using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSettings : MonoBehaviour
{
	public Player.races characterRace;
	public Player.classes characterClass;
	public Player.gender characterGender;
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

	private void Awake()
	{
		DontDestroyOnLoad(this.gameObject);

		SceneManager.sceneLoaded += OnSceneLoaded;

		void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			Debug.Log("Well... this might've worked?" + " " + scene.name);
			if (scene.name == "WorldScene")
			{
				Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
				player.characterClass = characterClass;
				player.characterGender = characterGender;
				player.characterRace = characterRace;
				player.GetComponent<CharacterAppearance>().head = head;
				player.GetComponent<CharacterAppearance>().neck = neck;
				player.GetComponent<CharacterAppearance>().shoulder = shoulder;
				player.GetComponent<CharacterAppearance>().back = back;
				player.GetComponent<CharacterAppearance>().chest = chest;
				player.GetComponent<CharacterAppearance>().shirt = shirt;
				player.GetComponent<CharacterAppearance>().tabard = tabard;
				player.GetComponent<CharacterAppearance>().wrist = wrist;
				player.GetComponent<CharacterAppearance>().hands = hands;
				player.GetComponent<CharacterAppearance>().waist = waist;
				player.GetComponent<CharacterAppearance>().legs = legs;
				player.GetComponent<CharacterAppearance>().feet = feet;
				player.GetComponent<CharacterAppearance>().ring1 = ring1;
				player.GetComponent<CharacterAppearance>().ring2 = ring2;
				player.GetComponent<CharacterAppearance>().trinket1 = trinket1;
				player.GetComponent<CharacterAppearance>().trinket2 = trinket2;
				player.GetComponent<CharacterAppearance>().mainhand = mainhand;
				player.GetComponent<CharacterAppearance>().offhand = offhand;
			}
		}
	}
}