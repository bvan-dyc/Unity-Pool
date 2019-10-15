using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerHudText : MonoBehaviour
{
	public towerScript towerscript;
	public Text cost;
	public Text damage;
	public Text range;
	public Text cooldown;

	void Update()
	{
		cost.text = towerscript.energy.ToString();
		damage.text = towerscript.damage.ToString();
		range.text = towerscript.range.ToString();
		cooldown.text = towerscript.fireRate.ToString();
	}
}

