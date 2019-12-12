using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttack : Spell
{

	float counter;
	[Header("Custom Fields")]
	[SerializeField]
	bool ToggleOn;

    void Start()
    {
		counter = entity.GetAttackSpeed();
    }

	public override void Use()
	{
		base.Use();

		if (ToggleOn == true)
		{
			ToggleOn = false;
			entity.attacking = false;
		}
		else
		{
			ToggleOn = true;
		}

	}

	private void Update()
	{
		if (ToggleOn == true)
		{
			if (entity.currentTarget.gameObject.GetComponent<Entity>().isDead)
				TurnOff();
			if (RangeCheck())
			{
				entity.attacking = true;
				AutoAttackEffect();
			}
			else if (entity.gameObject.GetComponent<Mob>())
			{
				entity.gameObject.GetComponent<Mob>().MoveTo(entity.currentTarget.transform.position, 2.5f);
			}
		}
		if(ToggleOn == false)
		{
			entity.attacking = false;
		}

	}

	void AutoAttackEffect()
	{
		if (entity.GetComponentInParent<Entity>())
		{
			if (counter <= 0)
			{
				if (entity.gameObject.GetComponent<Player>())
					entity.gameObject.GetComponent<PlayerController>().animController.SetTrigger("Attack");
				SchoolDamage((entity.level * 3) + (entity.GetAttackPower() / 14));
				if(entity.gameObject.GetComponent<Mob>())
					entity.gameObject.GetComponent<Mob>().animationController.SetTrigger("Attack");
				counter = entity.GetAttackSpeed();
			}
			else
			{
				//player.playerController.WeaponAttack(false);
				counter -= Time.deltaTime;
			}
		}
	}

	public override void Cancel()
	{
		base.Cancel();
		ToggleOn = false;
	}

	public void TurnOn()
	{
		ToggleOn = true;
	}

	public void TurnOff()
	{
		ToggleOn = false;
	}
}
