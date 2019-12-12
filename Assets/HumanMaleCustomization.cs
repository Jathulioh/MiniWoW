using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumanMaleCustomization : CharacterCustomization
{
	public int skinColorIndex;
	public GameObject skinLayer;

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
		if (skinColorIndex > (appearance[0].texturePart.Length - 1))
			skinColorIndex = 0;
	}
	public void skinPrevious()
	{
		skinColorIndex--;
		if (skinColorIndex < 0)
			skinColorIndex = (appearance[0].texturePart.Length - 1);
	}
	public void GetLayer(appearances.Appearances detail)
	{
		for (int i = 0; i < appearance.Length; i++)
		{
			if(this.gameObject.GetComponent<CharacterCustomization>().appearance[i].detail == appearances.Appearances.SKIN) {
				Debug.Log(skinColorIndex);
			}
		}
	}
}
