using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct LootTable
{

	public Items itemList;
	public int dropChance;

}

public class DropTable : MonoBehaviour
{

	public List<LootTable> dropList;

	void Start()
	{
		
	}

	void Loot()
	{

	}

	void QuestCheck()
	{
		foreach (LootTable item in dropList)
		{

		}
	}

}
