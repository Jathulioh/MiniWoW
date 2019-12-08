using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestChecking : MonoBehaviour
{

	public List<GameObject> QuestGivers;
	public List<Quest> totalAvailableQuests;
	public PlayerController pc;
    void Start()
    {
		pc = GetComponentInParent<PlayerController>();

		Entity[] listOfQuestGivers = FindObjectsOfType<Entity>();
		for (int i = 0; i < listOfQuestGivers.Length; i++)
		{
			if (listOfQuestGivers[i].quests.Count > 0)
			{
				QuestGivers.Add(listOfQuestGivers[i].gameObject);
			}
			
		}
		QuestCheck();
		AvailableQuests();
	}

	public void AvailableQuests()
	{
		
		foreach (Quest availableQuest in totalAvailableQuests) {
			availableQuest.GetComponentInParent<Entity>().AvailableQuests();
		}
	}

	public void QuestCheck()
	{
		foreach (GameObject questGiver in QuestGivers)
		{
			for (int i = 0; i < questGiver.GetComponent<Entity>().quests.Count; i++)
			{
				if (!pc.QuestBookCheck(questGiver.GetComponent<Entity>().quests[i].GetComponent<Quest>()) && pc.QuestRequirementCheck(questGiver.GetComponent<Entity>().quests[i].GetComponent<Quest>()))
				{
					totalAvailableQuests.Add(questGiver.GetComponent<Entity>().quests[i].GetComponent<Quest>());
				}
				else
				{
					totalAvailableQuests.Remove(questGiver.GetComponent<Entity>().quests[i].GetComponent<Quest>());
				}
			}
		}
		
	}

}
