using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBook : MonoBehaviour
{

	public List<Quest> questList;

	public void QuestListCheck()
	{

	}

	public void QuestCreatureCheck(int GroupID)
	{
		foreach (Quest quest in questList)
		{
			quest.Kills(GroupID);
		}
	}

}
