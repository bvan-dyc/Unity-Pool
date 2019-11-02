using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAOEEffect : MonoBehaviour
{
	[HideInInspector] public float damage;
	[HideInInspector] public float radius;
	[HideInInspector] public GameObject particleEffect;
	public Vector3 dropPosition;
	public float destroyAfterTime = 3;
	private void Start()
	{
		triggerAOE();
	}

	private void triggerAOE()
	{
		GameObject newEffect = Instantiate(particleEffect, gameObject.transform);
		newEffect.transform.position = dropPosition;
		Collider[] colliders = Physics.OverlapSphere(dropPosition, radius);
		foreach (Collider enemy in colliders)
		{
			if (enemy.tag == "Player")
				enemy.GetComponent<Damageable>().TakeDamage(Mathf.RoundToInt(damage), 100);
		}
		Invoke("destroyThis", destroyAfterTime);
	}
	private void destroyThis()
	{
		Destroy(gameObject);
	}
}
