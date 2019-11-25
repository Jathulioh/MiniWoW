using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spellbook : MonoBehaviour
{

	public List<GameObject> spells;

	private void Start()
	{
		spells.Add(GetComponentInChildren<Spell>().gameObject);
	}

}
