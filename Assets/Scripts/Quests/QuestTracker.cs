using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestTracker : MonoBehaviour
{
	Player player;
	QuestBook questBook;
	int currentTotalQuests = 0;
	public GameObject questTrackerText;
	public List<GameObject> trackerObjects = null;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		questBook = player.questBook;
		currentTotalQuests = questBook.questList.Count;
	}

	private void Update()
	{
		if (questBook.questList.Count != currentTotalQuests)
		{
			currentTotalQuests = questBook.questList.Count;
			UpdateTracker();
			
		}else
		UpdateObjectives();
	}

	void UpdateTracker()
	{
		Debug.Log("Quest Tracker Updated");
		foreach (GameObject go in trackerObjects)
		{
			Destroy(go);
		}
		trackerObjects.Clear();
		for (int i = 0; i < currentTotalQuests; i++)
		{
			trackerObjects.Add(Instantiate(questTrackerText, this.gameObject.transform));

			trackerObjects[i].GetComponent<questText>().name.text = questBook.questList[i].questName;
			for (int j = 0; j < questBook.questList[i].questTasks.Length; j++)
			{
				if (questBook.questList[i].questTasks[j].tasks == QuestObjectives.objectives.Talk)
				{
					trackerObjects[i].GetComponent<questText>().task.text = "Talk to " + questBook.questList[i].handIn.GetComponent<Entity>().entityName + " to hand in";
				}
				else if (questBook.questList[i].questTasks[j].tasks == QuestObjectives.objectives.Kills)
				{
					trackerObjects[i].GetComponent<questText>().task.text = "Kill " + questBook.questList[i].questTasks[j].numberDone + "/" + questBook.questList[i].questTasks[j].numberOf + " " + questBook.questList[i].questTasks[j].creatureNames + "";
				}
			}
		}
	}

	void UpdateObjectives()
	{
		for (int i = 0; i < currentTotalQuests; i++)
		{
			trackerObjects[i].GetComponent<questText>().name.text = questBook.questList[i].questName;
			for (int j = 0; j < questBook.questList[i].questTasks.Length; j++)
			{
				if (questBook.questList[i].questTasks[j].tasks == QuestObjectives.objectives.Talk)
				{
					trackerObjects[i].GetComponent<questText>().task.text = "Talk to " + questBook.questList[i].handIn.GetComponent<Entity>().entityName + " to hand in";
				}
				else if (questBook.questList[i].questTasks[j].tasks == QuestObjectives.objectives.Kills)
				{
					trackerObjects[i].GetComponent<questText>().task.text = "Kill " + questBook.questList[i].questTasks[j].numberDone + "/" + questBook.questList[i].questTasks[j].numberOf + " " + questBook.questList[i].questTasks[j].creatureNames + "";
				}
			}
		}
	}
}

