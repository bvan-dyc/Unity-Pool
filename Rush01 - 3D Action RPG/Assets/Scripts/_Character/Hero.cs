using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hero : Character
{
	[System.Serializable]
	public class LevelUpEvent : UnityEvent<Hero>
	{ }

	[System.Serializable]
	public class XPGainEvent : UnityEvent<Hero, float>
	{ }

	[SerializeField] private LevelUpEvent OnLevelUp = null;
	[SerializeField] private XPGainEvent OnXPGain = null;
	[SerializeField] private int attributePoints = 0;
	[SerializeField] private int attributePointsPerLevel = 1;
	[SerializeField] private int skillPoints = 0;
	[SerializeField] private int skillPointsPerLevel = 1;
	public GameObject[] activeSkills;
	public GameObject[] passiveSkills;
	private void Start()
	{
		/* temporary */
		foreach (GameObject heroSkill in activeSkills)
		{
			heroSkill.GetComponent<ActiveSkill>().user = this.gameObject;
		}
		foreach (GameObject heroSkill in passiveSkills)
		{
			heroSkill.GetComponent<PassiveSkill>().user = this.gameObject;
		}
	}

	public void LevelUp()
	{
		OnLevelUp.Invoke(this);
		data.level += 1;
		attributePoints += attributePointsPerLevel;
		skillPoints += skillPointsPerLevel;
	}

	public void GainXP(int amount)
	{
		data.xp += amount;
		OnXPGain.Invoke(this, amount);
		while (data.xp >= data.xpToNextLevel)
		{
			data.xp -= data.xpToNextLevel;
			/* temporary */
			data.xpToNextLevel *= 2;
			LevelUp();
		}
	}

	public void Equip(Equippable item)
	{
		data.damageMod += item.damage;
		data.armor += item.armor;
		data.agility += item.evasion;
		data.attackSpeedMod += item.attackSpeed;
	}

	public void Unequip(Equippable item)
	{
		data.damageMod -= item.damage;
		data.armor -= item.armor;
		data.agility -= item.evasion;
		data.attackSpeedMod -= item.attackSpeed;
	}
	public void SwitchEquips(Equippable oldEquip, Equippable newEquip)
	{
		Unequip(oldEquip);
		Equip(newEquip);
	}
	public void UseTalentPoint() {
		skillPoints--;
	}
	public void UseAttributePoint() {
		attributePoints--;
	}
	public int GetSkillsPoints() { return skillPoints; }
	public int GetAttributePoints() {return attributePoints;}
}
