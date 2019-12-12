using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{

	Text experienceText;
	Player player;

    // Start is called before the first frame update
    void Start()
    {
		experienceText = gameObject.GetComponent<Text>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
		experienceText.text = "" + player.experience + "/" + player.experienceTotal + " Experience";
    }
}
