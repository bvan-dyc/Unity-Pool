using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraEffect : MonoBehaviour
{
	public int dps = 10;
	public float duration = 5;
	[SerializeField] private float auraRadius = 1;
	[SerializeField] private float damageFrequency = 0.2f;
	private float timer = 0;
	private void Start()
	{
		StartCoroutine(AuraDamage());
		Destroy(gameObject, duration + damageFrequency / 2);
	}
	IEnumerator AuraDamage()
	{
		timer = 0;
		while (timer < duration)
		{
			Collider[] colliders = Physics.OverlapSphere(transform.position, auraRadius);
			foreach (Collider enemy in colliders)
			{
				if (enemy.tag == "enemy")
					enemy.GetComponent<Damageable>().TakeDamage(Mathf.RoundToInt(dps * damageFrequency), 100);
			}
			timer += damageFrequency;
			yield return new WaitForSeconds(damageFrequency);
		}
		yield return null;
	}
}
