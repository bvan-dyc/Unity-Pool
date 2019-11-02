using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
	public int strength = 10;
	public int agility = 10;
	public int constitution = 10;
	public int intelligence = 10;
	public int armor = 0;
	public int level = 1;
	public int xp = 0;
	public int xpToNextLevel = 100;
	public int credits = 0;
	public float attackSpeed = 1;
	public float attackSpeedMod = 0;
	public int damageMod = 0;
	public int maxHP
	{
		get { return constitution * 5; }
	}
	public int maxMana
	{
		get { return intelligence * 5; }
	}
	public int minDamage
	{
		get { return strength / 2 + damageMod; }
	}
	public int maxDamage
	{
		get { return strength / 2 + 4 + damageMod; }
	}
}
