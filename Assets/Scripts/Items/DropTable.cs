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

	public List<Items> droppedItems;

	void Start()
	{
		
	}

	public void CalculateLoot()
	{
		foreach (LootTable loot in dropList)
		{
			int lootDice = Random.Range(0, 100);
			if (lootDice <= loot.dropChance)
			{
				droppedItems.Add(loot.itemList);
			}
		}
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
