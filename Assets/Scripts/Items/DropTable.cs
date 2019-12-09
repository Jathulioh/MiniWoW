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

	public void CalculateLoot(GameObject looter)
	{
		for (int i = 0; i < droppedItems.Count; i++)
		{
			if (droppedItems[i] == null)
			{
				droppedItems.RemoveAt(i);
			}
			else
			{
				continue;
			}
		}

		foreach (LootTable loot in dropList)
		{
			if (loot.itemList.type == Items.itemType.Quest)
			{
				for (int i = 0; i < looter.GetComponent<Player>().questBook.questList.Count; i++)
				{
					if (looter.GetComponent<Player>().questBook.questList[i].questID == loot.itemList.questItemID)
					{
						int lootDice = Random.Range(0, 100);
						if (lootDice <= loot.dropChance)
						{
							droppedItems.Add(loot.itemList);
						}
					}
				}
			}
			else
			{
				int lootDice = Random.Range(0, 100);
				if (lootDice <= loot.dropChance)
				{
					droppedItems.Add(loot.itemList);
				}
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
