using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class QuestObjectives
{
	public enum objectives { Kills, Collect, Fetch }
	public objectives tasks;
	public int numberOf;
	public int numberDone;
	public int creatureGroupID;
	public bool completed;
}

public class Quest : MonoBehaviour
{

	public int levelRequirement = 0;

	public QuestObjectives[] questTasks;


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

}