using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
	[Range(0.1f, 30f)] public float spawnDelay_s = 10.0f;
	public bool uniqueSpawn = true;
	public UnitManager unitManager;
	private float timer = 0.0f;
	void Start()
	{
		if (timer == 0.0f)
			timer = 0.1f;
		if (uniqueSpawn) {
			unitManager.spawnUnit(transform.position);
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (!uniqueSpawn)
			timer -= Time.deltaTime;
		if (timer <= 0)
		{
			unitManager.spawnUnit(transform.position);
			timer = spawnDelay_s;
		}
	}
}
