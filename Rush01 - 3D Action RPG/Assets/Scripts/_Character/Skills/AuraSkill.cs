using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraSkill : ActiveSkill
{
	public int dps = 10;
	public float duration = 5;
	private GameObject currentEffect;
	public override void Activate()
	{
		base.Activate();
		Destroy(currentEffect);
		currentEffect = Instantiate(effectPrefab, user.transform);
		currentEffect.GetComponent<AuraEffect>().dps = dps;
		currentEffect.GetComponent<AuraEffect>().duration = duration;
	}
}
