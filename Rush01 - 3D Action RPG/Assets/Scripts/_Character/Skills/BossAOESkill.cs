using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAOESkill : ActiveSkill
{
	public float AOERadius = 5;
	public float damage = 5;
	[SerializeField] private GameObject AOEGenerator;

	public override void Activate()
	{
		base.Activate();
		GameObject newAOEGenerator = Instantiate(AOEGenerator);
		newAOEGenerator.transform.position = target ? target.transform.position : user.transform.position;
		newAOEGenerator.GetComponent<BossAOEEffect>().damage = damage;
		newAOEGenerator.GetComponent<BossAOEEffect>().radius = AOERadius;
		newAOEGenerator.GetComponent<BossAOEEffect>().particleEffect = effectPrefab;
		newAOEGenerator.GetComponent<BossAOEEffect>().dropPosition = target.transform.position;
	}
}