using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damager : MonoBehaviour
{
	[System.Serializable]
	public class DamagableEvent : UnityEvent<Damager, Damageable>
	{ }

	[System.Serializable]
	public class NonDamagableEvent : UnityEvent<Damager>
	{ }

	[SerializeField] private DamagableEvent OnDamageableHit = null;
	[SerializeField] private NonDamagableEvent OnNonDamageableHit = null;
	private bool canDamage = true;

	public void EnableDamage()
	{
		canDamage = true;
	}

	public void DisableDamage()
	{
		canDamage = false;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!canDamage)
			return;
		Damageable damageable = collision.gameObject.GetComponent<Damageable>();
		if (damageable)
		{
			OnDamageableHit.Invoke(this, damageable);
			damageable.takeHit(this);
		}
		else
		{
			OnNonDamageableHit.Invoke(this);
		}
	}
}
