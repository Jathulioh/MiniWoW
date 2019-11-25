using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActionBarButton : MonoBehaviour
{

	public GameObject action;
	public KeyCode boundKey;
	Image icon;

    // Start is called before the first frame update
    void Start()
    {
		icon = GameObject.Find("Image/SpellIcon").GetComponent<Image>();
		ActionCheck();
    }

    // Update is called once per frame
    void Update()
    {
		ActionCheck();

		if (Input.GetKeyUp(boundKey)) {
			action.GetComponent<Spell>().Use();
		}

    }

	void ActionCheck()
	{
		if (action == null)
		{
			icon.enabled = false;
			return;
		}
		else
		{
			if (!action.GetComponent<Spell>())
			{
				action = null;
				icon.enabled = false;
			}
			else
			{
				icon.enabled = true;
				icon.sprite = action.GetComponent<Spell>().spellIcon;
			}
		}
	}

}
