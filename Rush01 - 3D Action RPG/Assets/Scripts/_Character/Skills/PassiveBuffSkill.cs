using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveBuffSkill : PassiveSkill
{
    [Header("Buffing")]
    public BuffType buffType;
    [SerializeField] private int buffAmount = 1;
    public bool isPercentageBased = false;
    private int currentBuff = 0;
    public enum BuffType {
        strength,
        armor,
        evasion,
		attackSpeed,
    }
    public override void Activate() {
		isEnabled = true;
        switch (buffType) {
            case BuffType.strength:
                {
                    currentBuff = isPercentageBased ? (1 / user.GetComponent<CharacterData>().strength) * (100 + buffAmount) : buffAmount;
                    user.GetComponent<CharacterData>().strength += buffAmount;
                    break;
                }
            case BuffType.armor:
                {
                    currentBuff = isPercentageBased ? (1 / user.GetComponent<CharacterData>().armor) * (100 + buffAmount) : buffAmount;
                    user.GetComponent<CharacterData>().armor += buffAmount;
                    break;
                }
            case BuffType.evasion:
                {
                    currentBuff = isPercentageBased ? (1 / user.GetComponent<CharacterData>().agility) * (100 + buffAmount) : buffAmount;
                    user.GetComponent<CharacterData>().agility += buffAmount;
                    break;
                }
			case BuffType.attackSpeed:
				{
					user.GetComponent<CharacterData>().attackSpeedMod += (float)buffAmount / 100f;
						break;
				}
        }
    }

	public override void Desactivate()
	{
		switch (buffType)
		{
			case BuffType.strength:
				{
					user.GetComponent<CharacterData>().strength -= currentBuff;
					currentBuff = 0;
					break;
				}
			case BuffType.armor:
				{
					user.GetComponent<CharacterData>().armor += buffAmount;
					break;
				}
			case BuffType.evasion:
				{
					user.GetComponent<CharacterData>().agility -= currentBuff;
					currentBuff = 0;
					break;
				}
		}
	}
}
