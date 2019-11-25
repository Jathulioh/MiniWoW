using UnityEngine;
using UnityEngine.UI;
public class Portrait : MonoBehaviour
{
	Player player;
	GameObject playerFrame;
	GameObject playerName;
	GameObject levelText;
	GameObject healthPoints;

	// Start is called before the first frame update
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		playerFrame = GameObject.Find("GameUI/playerFramePanel");
		levelText = GameObject.Find("GameUI/playerFramePanel/levelText");
		playerName = GameObject.Find("GameUI/playerFramePanel/playerName");
		healthPoints = GameObject.Find("GameUI/playerFramePanel/healthPointText");
	}

	// Update is called once per frame
	void Update()
	{
			playerFrame.SetActive(true);
			playerName.GetComponent<Text>().text = player.GetComponent<Entity>().entityName;
			levelText.GetComponent<Text>().text = player.GetComponent<Entity>().level.ToString();
			healthPoints.GetComponent<Text>().text = player.GetComponent<Entity>().GetCurrentHealth().ToString() + "/" + player.GetComponent<Entity>().GetTotalHealth().ToString();
	}
}
