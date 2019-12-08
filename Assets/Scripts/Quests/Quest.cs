using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class QuestObjectives
{
	public enum objectives {Kills, Collect, Fetch, Talk}
	public objectives tasks;
	public int numberOf;
	public int numberDone;
	public int creatureGroupID;
	public bool completed;
}

public class Quest : MonoBehaviour
{
	public bool active;
	public int questID;
	public string questName;
	[TextArea(20, 100)]
	public string questDescription;
	public int levelRequirement = 0;
	public Player.classes[] classRequirement;
	public List<int> questRequirement;

	public QuestObjectives[] questTasks;

	public Items[] itemReward;
	public Items[] choiceReward;
	public int experienceReward;

	public GameObject handIn;

	private void Start()
	{
		/*if (CompletionCheck() == true && active == true)
		{
			handIn.GetComponent<Entity>().QuestHandIn(CompletionCheck());
		}
		else if(CompletionCheck() == false && active == true)
		{
			handIn.GetComponent<Entity>().QuestHandIn(CompletionCheck());
		}*/
	}

	private void Update()
	{
		if (CompletionCheck() == true && active == true)
		{
			handIn.GetComponent<Entity>().PendingHandIn();
			if (!handIn.GetComponent<Entity>().questHandIns.Contains(this.gameObject))
			{
				handIn.GetComponent<Entity>().questHandIns.Add(this.gameObject);
			}
		}
		else if (CompletionCheck() == false && active == true)
		{
			handIn.GetComponent<Entity>().PendingCompletion();
		}
	}

	public void Kills(int creatureGID)
	{
		foreach  (QuestObjectives tasks in questTasks)
		{
			if (tasks.creatureGroupID != -1)
			{
				if (tasks.creatureGroupID == creatureGID)
				{
					tasks.numberDone += 1;

					if (tasks.numberDone == tasks.numberOf)
						tasks.completed = true;
				}
			}
		}
	}

	public void Collect()
	{

	}

	public void Fetch()
	{

	}

	public void Talk()
	{
		foreach (QuestObjectives questObjectives in questTasks)
		{
			if (questObjectives.tasks == QuestObjectives.objectives.Talk)
			{
				questObjectives.completed = true;
			}
		}
	}

	public bool CompletionCheck()
	{
		for (int i = 0; i < questTasks.Length; ++i)
		{
			if (questTasks[i].completed == false)
			{
				return false;
			}
		}
		return true;
	}

	public void ClearHandInCheck()
	{
		handIn.GetComponent<Entity>().questHandIns.Remove(this.gameObject);
	}

}