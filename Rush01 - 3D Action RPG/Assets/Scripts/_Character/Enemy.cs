using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
	[SerializeField] private int abilityPointsPerLevel = 3;
	[SerializeField] private int strengthUpgradeChance = 150;
	[SerializeField] private int armorUpgradeChance = 10;
	[SerializeField] private int constitutionUpgradeChance = 150;
	[SerializeField] private int evasionUpgradeChance = 10;
	[SerializeField] private int xpMultiplierPerLevel = 130;
	[SerializeField] private int creditMultiplierPerLevel = 130;
	public void setLevel(int newLevel)
	{
		if (newLevel <= data.level)
			return;
		newLevel -= data.level;
		data.xp += Mathf.RoundToInt(newLevel * xpMultiplierPerLevel / 100);
		data.credits += Mathf.RoundToInt(newLevel * creditMultiplierPerLevel / 100);
		data.strength += Mathf.RoundToInt(newLevel * strengthUpgradeChance / 100);
		data.armor += Mathf.RoundToInt(newLevel * armorUpgradeChance / 100);
		data.constitution += Mathf.RoundToInt(newLevel * constitutionUpgradeChance / 100);
		data.agility += Mathf.RoundToInt(newLevel * evasionUpgradeChance / 100);
	}
}
