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
	public List<Quest> completedQuests;
	public GameObject acceptQuestInterface;
	public GameObject completeQuestInterface;
	public GameObject player;
	public bool buttonListener;

	public void AcceptQuests(int ID)
	{
		GameObject temp = Instantiate(availableQuests[ID].gameObject, player.GetComponent<Player>().questBook.gameObject.transform);
		temp.GetComponent<Quest>().active = true;
		player.GetComponent<Player>().questBook.questList.Add(temp.GetComponent<Quest>());
	}
	public void CompleteQuests(int ID)
	{
		GameObject temp = completedQuests[ID].gameObject;
		player.GetComponent<Player>().questBook.completedQuestList.Add(temp.GetComponent<Quest>().questID);
		player.GetComponent<Player>().AddExperience(temp.GetComponent<Quest>().experienceReward);
		temp.GetComponent<Quest>().active = false;
		player.GetComponent<Player>().questBook.questList.Remove(temp.GetComponent<Quest>());
		temp.GetComponent<Quest>().ClearHandInCheck();
		Destroy(temp);
	}

	public void ButtonListeners()
	{
		GameObject lastClickedButton = EventSystem.current.currentSelectedGameObject;
		if (buttonListener)
		{
			Debug.Log("accpeted quest?");
			Destroy(lastClickedButton);
			AcceptQuests(lastClickedButton.GetComponent<QuestID>().questID);
		}
		else
		{
			Destroy(lastClickedButton);
			CompleteQuests(lastClickedButton.GetComponent<QuestID>().questID);
		}
	}

	public void GenerateList(List<Quest> questType, GameObject questInterface, bool listener)
	{
		float y = 0;
		buttonListener = listener;
		for (int i = 0; i < questType.Count; i++)
		{
			GameObject temp = Instantiate(questButtonPrefab, questInterface.transform);
			temp.transform.position += new Vector3(0,y,0);
			temp.GetComponentInChildren<Text>().text = questType[i].questName;
			buttonList.Add(temp);
			y -= 25;
			buttonList[i].AddComponent<QuestID>();
			buttonList[i].GetComponent<QuestID>().questID = i;
			buttonList[i].GetComponent<Button>().onClick.AddListener(ButtonListeners);
		}
	}

	public void OpenAvailable(GameObject pc)
	{
		acceptQuestInterface.SetActive(true);
		player = pc;
	}
	public void CloseAvailable()
	{
		ClearAvailable();
		acceptQuestInterface.SetActive(false);
		player = null;
	}
	public void ClearAvailable()
	{
		foreach (GameObject button in buttonList)
		{
			Destroy(button);
		}
		buttonList.Clear();
		availableQuests.Clear();
	}

	public void OpenCompleted(GameObject pc)
	{
		completeQuestInterface.SetActive(true);
		player = pc;
	}
	public void CloseCompleted()
	{
		ClearCompleted();
		completeQuestInterface.SetActive(false);
		player = null;
	}
	public void ClearCompleted()
	{
		foreach (GameObject button in buttonList)
		{
			Destroy(button);
		}
		buttonList.Clear();
		completedQuests.Clear();
	}
}
