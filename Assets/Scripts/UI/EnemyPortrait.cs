using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPortrait : MonoBehaviour
{

	Player player;
	GameObject targetFrame;
	GameObject targetName;
	GameObject levelText;
	GameObject healthPoints;

    // Start is called before the first frame update
    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		targetFrame = GameObject.Find("GameUI/targetFramePanel");
		levelText = GameObject.Find("GameUI/targetFramePanel/levelText");
		targetName = GameObject.Find("GameUI/targetFramePanel/targetName");
		healthPoints = GameObject.Find("GameUI/targetFramePanel/healthPointText");
	}

    // Update is called once per frame
    void Update()
    {

		if (player.currentTarget != null)
		{
			targetFrame.SetActive(true);
			targetName.GetComponent<Text>().text = player.currentTarget.GetComponent<Entity>().entityName;
			levelText.GetComponent<Text>().text = player.currentTarget.GetComponent<Entity>().level.ToString();
			healthPoints.GetComponent<Text>().text = player.currentTarget.GetComponent<Entity>().GetCurrentHealth().ToString() + "/" + player.currentTarget.GetComponent<Entity>().GetTotalHealth().ToString();
		}
		else
		{
			targetFrame.SetActive(false);
		}

	}
}
