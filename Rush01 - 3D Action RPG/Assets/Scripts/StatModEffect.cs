using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatModEffect : MonoBehaviour
{
	private GameObject target;
	[Header("Mod")]
	public ModType modType;
	[SerializeField] private int modAmount = 5;
	private int currentMod = 0;
	private bool isPercentageBased = false;
	public float duration = 5;
	public enum ModType
	{
		strength,
		armor,
		evasion,
		attackSpeed,
	}
	void Start()
    {
		target = transform.parent.gameObject;
		switch (modType)
		{
			case ModType.strength:
				{
					currentMod = isPercentageBased ? (1 / target.GetComponent<CharacterData>().strength) * (100 + modAmount) : modAmount;
					target.GetComponent<CharacterData>().strength += modAmount;
					break;
				}
			case ModType.armor:
				{
					currentMod = isPercentageBased ? (1 / target.GetComponent<CharacterData>().armor) * (100 + modAmount) : modAmount;
					target.GetComponent<CharacterData>().armor += modAmount;
					break;
				}
			case ModType.evasion:
				{
					currentMod = isPercentageBased ? (1 / target.GetComponent<CharacterData>().agility) * (100 + modAmount) : modAmount;
					target.GetComponent<CharacterData>().agility += modAmount;
					break;
				}
			case ModType.attackSpeed:
				{
					target.GetComponent<CharacterData>().attackSpeedMod += modAmount;
					break;
				}
		}
		Invoke("Desactivate", duration);
	}

	public void Desactivate()
	{
		switch (modType)
		{
			case ModType.strength:
				{
					target.GetComponent<CharacterData>().strength -= currentMod;
					currentMod = 0;
					break;
				}
			case ModType.armor:
				{
					target.GetComponent<CharacterData>().armor -= currentMod;
					break;
				}
			case ModType.evasion:
				{
					target.GetComponent<CharacterData>().agility -= currentMod;
					currentMod = 0;
					break;
				}
		}
	}
}
