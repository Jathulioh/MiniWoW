using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMaleCustomization : CharacterCustomization
{
	public int skinColorIndex;

	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.RightBracket)){
			skinNext();
		}
		if (Input.GetKeyUp(KeyCode.LeftBracket)){
			skinPrevious();
		}
	}
	public void skinNext()
	{
		skinColorIndex++;
	}
	public void skinPrevious()
	{
		skinColorIndex--;
	}
	public void GetLayer(appearances.Appearances detail)
	{
		for (int i = 0; i < appearance.Length; i++)
		{
			if(this.gameObject.GetComponent<CharacterCustomization>().appearance[i].detail == appearances.Appearances.SKIN) {
				Debug.Log("This is el skin");
			}
		}
	}
}
