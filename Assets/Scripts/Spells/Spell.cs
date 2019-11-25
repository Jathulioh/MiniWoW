using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
	[HideInInspector]
	public Entity entity;

	public enum usedResource {None, Mana, Energy, Rage}
	public enum magicSchool {Arcane, Fire, Frost, Holy, Nature, Physical, Shadow}
	public enum spellEffects {SchoolDamage, AoE}
	[Header("Spell Info")]
	public string spellName;
	public string spellDescription;
	public Sprite spellIcon;

	[Header("Spell Details")]
	public usedResource resource;
	public int cost;
	public float range;
	public float castTime;
	public float cooldown;
	public bool GCD;
	public magicSchool school;
	public spellEffects[] effects;

	private void Awake()
	{
		entity = gameObject.GetComponentInParent<Entity>();
	}

	private void LateUpdate()
	{
		if (Input.GetButtonUp("Cancel"))
			CancelSpell();
	}

	public virtual void Use()
	{
		if (!TargetCheck() || !RangeCheck())
		{
			if (entity.gameObject.GetComponent<Mob>())
			{
				entity.gameObject.GetComponent<Mob>().MoveTo(entity.currentTarget.transform.position, 2.5f);
			}
			else
			{
				return;
			}
		}
			
		

	}

	public void SchoolDamage(int damage)
	{
		if (school == magicSchool.Physical && TargetCheck()){
			entity.currentTarget.GetComponent<Entity>().TakeDamage(damage, entity.gameObject);
		}
	}

	public bool TargetCheck()
	{
		if (entity.currentTarget == null)
		{
			return false;
		}
		else
		{
			Debug.Log("Current Target == " + entity.currentTarget);
			return true;
		}
	}

	public bool RangeCheck()
	{
		if (entity.currentTarget != null)
		{
			float distance = Vector3.Distance(entity.gameObject.transform.position, entity.currentTarget.gameObject.transform.position);
			if (distance <= range)
			{
				return true;
			}
			else
			{
				//Debug.Log("You're out of range");
				return false;
			}
		}
		else
		{
			//Debug.Log("I don't have a target");
			return false;
		}
	}

	void CancelSpell()
	{
		Cancel();
	}

	public virtual void Cancel()
	{

	}

}
