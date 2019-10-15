using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
	public UnitSpawner mainTower;

	private void OnDestroy()
	{
		mainTower.spawnDelay_s += 2.5f;
	}
}
