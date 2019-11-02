using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ActiveSkill : Skill
{
	[System.Serializable]
	public class ActivateEvent : UnityEvent<ActiveSkill>
	{ }
	[SerializeField] protected ActivateEvent OnSkillActivated = null;

	[SerializeField] protected GameObject effectPrefab;
	public activeSkillType activeType;

	public int cost = 10;
	[SerializeField] protected bool debug_activateSkill = false;
	public GameObject user;
	public GameObject target;
	public enum activeSkillType
	{
		Healing,
		AOE,
		Ranged,
		Aura
	}
	public void Start()
	{
		tooltip += "/nCost: " + cost;
	}
	public virtual void Activate()
	{
		OnSkillActivated.Invoke(this);
	}
}
