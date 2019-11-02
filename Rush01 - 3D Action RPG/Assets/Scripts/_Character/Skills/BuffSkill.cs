using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSkill : ActiveSkill
{
	[SerializeField] private GameObject statModObject;
	private GameObject newStatMod = null; 
	public override void Activate()
	{
		base.Activate();
		if (newStatMod)
			Destroy(newStatMod);
		newStatMod = Instantiate(statModObject, user.transform);
	}
}
