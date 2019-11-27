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
	Player player;

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
		Controls();
		Movement();
		Rotation();
		AnimationSettings();
		Combat();
    }

	void Movement()
	{
		if (cc.isGrounded)
		{
			if (Input.GetMouseButton(1))
			{
				Cursor.visible = false;
				moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
			}
			else
			{
				Cursor.visible = true;
				moveDirection = new Vector3(0.0f, 0.0f, Input.GetAxisRaw("Vertical"));
			}
			if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
			{
				Cursor.visible = false;
				moveDirection = new Vector3(0.0f, 0.0f, 1.0f);
			}
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

	void Combat()
	{
		if (Input.GetMouseButtonUp(1) && player.hoverTarget != null)
		{
			player.currentTarget = player.hoverTarget;
			foreach (GameObject spell in player.spellBook.spells)
			{
				if (spell.name == "AutoAttack")
				{
					spell.GetComponent<Spell>().Use();
				}
			}
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