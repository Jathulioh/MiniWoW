using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AcceptQuest : MonoBehaviour
{

	public GameObject questButtonPrefab;
	public List<GameObject> buttonList;
	public List<Quest> availableQuests;
	public GameObject questInterface;
	public GameObject player;

	public void AcceptQuests(int ID)
	{
		Debug.Log(ID);
		player.GetComponent<Player>().questBook.questList.Add(availableQuests[ID]);
	}

	public void ButtonListeners()
	{
		AcceptQuests(EventSystem.current.currentSelectedGameObject.GetComponent<QuestID>().questID);
	}

	public void GenerateList()
	{
		float y = 0;
		for (int i = 0; i < availableQuests.Count; i++)
		{
			GameObject temp = Instantiate(questButtonPrefab, questInterface.transform);
			temp.transform.position += new Vector3(0,y,0);
			temp.GetComponentInChildren<Text>().text = availableQuests[i].questName;
			buttonList.Add(temp);
			y -= 25;
			buttonList[i].AddComponent<QuestID>();
			buttonList[i].GetComponent<QuestID>().questID = i;
			buttonList[i].GetComponent<Button>().onClick.AddListener(ButtonListeners);
		}
	}

	public void Open(GameObject pc)
	{
		questInterface.SetActive(true);
		player = pc;
	}

	public void Close()
	{
		Clear();
		questInterface.SetActive(false);
		player = null;
	}
	public void Clear()
	{
		foreach (GameObject button in buttonList)
		{
			Destroy(button);
		}
		buttonList.Clear();
		availableQuests.Clear();
	}
}
