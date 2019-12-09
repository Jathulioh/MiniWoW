using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{

	public float moveSpeed = 6.4f;
	private float walkSpeed = 2.286f;
	private float runSpeed = 6.4f;
	public float jumpSpeed = 5;
	public float gravity = 9.4f;

	CharacterController cc;
	public Animator animController;
	Camera mainCam;
	[HideInInspector]public Player player;

	private Vector3 moveDirection;
	private float yaw;
	private float rotationSensitivity = 2;

	private void Awake()
	{
		cc = this.gameObject.GetComponent<CharacterController>();
		player = this.gameObject.GetComponent<Player>();
		mainCam = Camera.main;
	}

	void Start()
    {
		moveSpeed = runSpeed;
		//animController.SetBool("isMoving", false);
    }

    // Update is called once per frame
    void Update()
    {
		Interact();
		Controls();
		Movement();
		Rotation();
		AnimationSettings();
    }

	void Movement()
	{
		if (cc.isGrounded)
		{
			if (Input.GetMouseButton(1))
			{
				Cursor.visible = false;
				Cursor.lockState = CursorLockMode.Confined;
				moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
			}
			else
			{
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
				moveDirection = new Vector3(0.0f, 0.0f, Input.GetAxisRaw("Vertical"));
			}
			if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
			{
				Cursor.visible = false;
				Cursor.lockState = CursorLockMode.Confined;
				moveDirection = new Vector3(0.0f, 0.0f, 1.0f);
			}
			moveDirection.x = Input.GetAxisRaw("Strafe");

			moveDirection = moveDirection.normalized;
			moveDirection *= moveSpeed;

			if (Input.GetButton("Jump"))
			{
				moveDirection.y = jumpSpeed;
			}
		}
			moveDirection.y -= gravity * Time.deltaTime;

		cc.Move(transform.TransformDirection(moveDirection) * Time.deltaTime);
		/*if 
		{
			animController.SetBool("isMoving", false);
		}*/


	}

	void Rotation()
	{
		if (Input.GetMouseButton(1))
		{
			Vector3 euler = mainCam.transform.rotation.eulerAngles;
			Quaternion rot = Quaternion.Euler(0, euler.y, 0);
			transform.rotation = rot;
			yaw = euler.y;
		}
		else
		{
			yaw += rotationSensitivity * Input.GetAxisRaw("Horizontal");

			transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
		}
	}

	void Controls()
	{
		if (Input.GetButtonUp("Walk/Run Toggle") && moveSpeed == runSpeed)
		{
			moveSpeed = walkSpeed;
		}
		else if (Input.GetButtonUp("Walk/Run Toggle") && moveSpeed == walkSpeed)
		{
			moveSpeed = runSpeed;
		}
		//animController.SetFloat("moveSpeed", moveSpeed);
	}

	void Interact()
	{
		if (Input.GetMouseButtonUp(1) && player.hoverTarget != null)
		{
			player.currentTarget = player.hoverTarget;

			if (player.currentTarget.GetComponent<Entity>().allignment != player.allignment && player.currentTarget.GetComponent<Mob>() && !player.currentTarget.GetComponent<Entity>().isDead && player.currentTarget.GetComponent<Entity>().attackable)
			{
				if (player.allignment == Entity.sides.Alliance)
				{
					if (player.currentTarget.GetComponent<Mob>().reactAlliance == Mob.react.Hostile)
					{
						Combat();
					}
				}
				else if (player.allignment == Entity.sides.Horde)
				{
					if (player.currentTarget.GetComponent<Mob>().reactHorde == Mob.react.Hostile)
					{
						Combat();
					}
				}
			}
			else if (player.currentTarget.GetComponent<Entity>().isDead && player.currentTarget.GetComponent<Entity>().isLootable)
			{
				Loot();
			}
			else if (player.currentTarget.GetComponent<Entity>().questHandIns.Count > 0)
			{
				CompleteQuestFrame();
			}
			else if (player.currentTarget.GetComponent<Entity>().quests.Count > 0)
			{
				AcceptQuestFrame();
			}
		}
	}

	void Combat()
	{
		if (player.currentTarget.GetComponent<Entity>().isDead)
		{
			Debug.Log("I can't attack that target");
			return;
		}
		foreach (GameObject spell in player.spellBook.spells)
		{
			if (spell.name == "AutoAttack")
			{
				spell.GetComponent<Spell>().Use();
			}
		}
	}

	void Loot()
	{
		player.lootFrame.lootable = null;
		player.lootFrame.lootable = player.currentTarget.GetComponent<DropTable>().droppedItems;
		player.lootFrame.looter = player.gameObject;
		player.lootFrame.ResetList();
		player.lootFrame.SortItems();
	}

	public void AcceptQuestFrame()
	{
		player.questFrame.ClearAvailable();
		for (int i = 0; i < player.currentTarget.GetComponent<Entity>().quests.Count; i++)
		{
			if (!QuestBookCheck(player.currentTarget.GetComponent<Entity>().quests[i].GetComponent<Quest>()) && QuestRequirementCheck(player.currentTarget.GetComponent<Entity>().quests[i].GetComponent<Quest>()))
			{
				//Debug.Log("acceptable quests: " + player.currentTarget.GetComponent<Entity>().quests[i].GetComponent<Quest>());
				player.questFrame.availableQuests.Add(player.currentTarget.GetComponent<Entity>().quests[i].GetComponent<Quest>());
			}
			else
			{
				Debug.Log("You cant accept: " + player.currentTarget.GetComponent<Entity>().quests[i].GetComponent<Quest>());
			}
		}

		player.questFrame.GenerateList(player.questFrame.availableQuests, player.questFrame.acceptQuestInterface, true);
		player.questFrame.OpenAvailable(this.gameObject);
	}

	public void CompleteQuestFrame()
	{
		player.questFrame.ClearCompleted();
		for (int i = 0; i < player.currentTarget.GetComponent<Entity>().questHandIns.Count; i++)
		{
			player.questFrame.completedQuests.Add(player.currentTarget.GetComponent<Entity>().questHandIns[i].GetComponent<Quest>());
		}
		player.questFrame.GenerateList(player.questFrame.completedQuests, player.questFrame.completeQuestInterface, false);
		player.questFrame.OpenCompleted(this.gameObject);
	}

	public bool QuestBookCheck(Quest q)
	{
		if (player.questBook.questList.Count > 0)
		{
			for (int i = 0; i < player.questBook.questList.Count; i++)
			{
				if (player.questBook.questList[i].questID == q.questID)
				{
					return true;
				}
			}
		}
		if (player.questBook.completedQuestList.Count > 0)
		{
			for (int j = 0; j < player.questBook.completedQuestList.Count; j++)
			{
				if (player.questBook.completedQuestList[j] == q.questID)
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool QuestRequirementCheck(Quest q)
	{
		if (q.levelRequirement > player.level)
		{
			return false;
		}
		else
		{
			if (q.classRequirement.Length != 0)
			{
				for (int i = 0; i < q.classRequirement.Length; i++)
				{
					if (q.classRequirement[i] == player.characterClass)
					{
						goto QuestReq;
					}
				}
				return false;
			}
			else
			{
				goto QuestReq;
			}
		}

		QuestReq:
		if (q.questRequirement.Count != 0)
		{
			for (int i = 0; i < q.questRequirement.Count; i++)
			{
				if (player.questBook.completedQuestList.Contains(q.questRequirement[i]))
				{
					return true;
				}
			}
			return false;
		}
		else
		{
			return true;
		}
	}

	void AnimationSettings()
	{
		if (player.attacking)
		{
			//animController.SetBool("inCombat", true);
		}
		else
		{
			//animController.SetBool("inCombat", false);
		}
	}

	public void WeaponAttack(bool attack)
	{
		animController.SetBool("Attack", attack);
	}



}