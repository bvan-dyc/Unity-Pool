using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	public CharacterData data;

    private void Awake()
    {
		data = GetComponent<CharacterData>();
    }

	public int computeDamage()
	{
		return (Random.Range(data.minDamage, data.maxDamage));
	}

	public int computeHitChance()
	{
		return (75 + data.agility);
	}
}
