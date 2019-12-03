using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootFrame : MonoBehaviour
{

	public List<Items> lootable;
	public List<GameObject> itemToast;
	public GameObject lootInterface;
	public GameObject looter;
    // Update is called once per frame
    void Update()
    {

    }

	public void Looter(GameObject looterGO)
	{
		looter = looterGO;
	}

	public void SortItems()
	{
		lootInterface.SetActive(true);
		if (lootable.Count <= 3)
		{
			for (int i = 0; i < lootable.Count; i++)
			{
				if (lootable[i] != null)
				{
					itemToast[i].GetComponent<ItemToast>().icon.GetComponent<Image>().sprite = lootable[i].itemIcon;
					itemToast[i].GetComponent<ItemToast>().name.GetComponent<Text>().text = lootable[i].itemName;
					itemToast[i].GetComponent<ItemToast>().occupied = true;
					
					itemToast[i].SetActive(true);
				}
				else
				{
					continue;
				}
			}
		}
		else
		{
			Debug.Log("Too many items come back later");
		}
	}

	public void ResetList()
	{
		for (int i = 0; i < itemToast.Count; i++)
		{
			itemToast[i].GetComponent<ItemToast>().icon.GetComponent<Image>().sprite = null;
			itemToast[i].GetComponent<ItemToast>().name.GetComponent<Text>().text = null;
			itemToast[i].GetComponent<ItemToast>().occupied = false;
			itemToast[i].SetActive(false);
		}

		/*for (int i = 0; i < lootable.Count; i++)
		{
			lootable[i] = null;
		}*/

	}

	public void firstItem()
	{
		if (itemToast[0].GetComponent<ItemToast>().occupied == true)
		{
			for (int i = 0; i < looter.GetComponent<Inventory>().inventory.Count; i++)
			{
				if (looter.GetComponent<Inventory>().inventory[i] == null)
				{
					looter.GetComponent<Inventory>().inventory[i] = lootable[0];
					itemToast[0].SetActive(false);
					lootable[0] = null;
				}
				else
				{
					continue;
				}
			}
		}
	}

	public void secondItem()
	{
		if (itemToast[1].GetComponent<ItemToast>().occupied == true)
		{
			for (int i = 0; i < looter.GetComponent<Inventory>().inventory.Count; i++)
			{
				if (looter.GetComponent<Inventory>().inventory[i] == null)
				{
					looter.GetComponent<Inventory>().inventory[i] = lootable[1];
					itemToast[1].SetActive(false);
					lootable[1] = null;
				}
				else
				{
					continue;
				}
			}
		}
	}

	public void thirdItem()
	{
		if (itemToast[2].GetComponent<ItemToast>().occupied == true)
		{
			for (int i = 0; i < looter.GetComponent<Inventory>().inventory.Count; i++)
			{
				if (looter.GetComponent<Inventory>().inventory[i] == null)
				{
					looter.GetComponent<Inventory>().inventory[i] = lootable[2];
					itemToast[2].SetActive(false);
					lootable[2] = null;
				}
				else
				{
					continue;
				}
			}
		}
	}

	public void Close()
	{
		lootInterface.SetActive(false);
	}

}
