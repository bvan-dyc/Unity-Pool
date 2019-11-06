using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
	public int strength = 10;
	public int agility = 10;
	public int constitution = 10;
	public int armor = 0;
	public int level = 1;
	public int xp = 0;
	public int xpToNextLevel = 100;
	public int credits = 0;
	public int hp;
	private int minDamage;
	private int maxDamage;
	// Start is called before the first frame update
	void Awake()
    {
		initStats();
    }

	private void Update()
	{
		if (xp > xpToNextLevel)
		{
			level += 1;
			xp = 0;
			xpToNextLevel *= 2;
		}
	}
	private void initStats()
	{
		hp = 5 * constitution;
		minDamage = strength / 2;
		maxDamage = minDamage + 4;
	}

	public int computeDamage()
	{
		return (Random.Range(minDamage, maxDamage));
	}

	public int computeHitChance()
	{
		return (75 + agility);
	}
}
