using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Damageable : MonoBehaviour
{
	[System.Serializable] public class DamageEvent : UnityEvent<Damager, Damageable>
	{ }
	[SerializeField] private bool disableOnDeath = false;
	[SerializeField] private bool destroyOnDeath = false;
	[SerializeField] private DamageEvent OnDie = null;
	private bool invulnerable = false;

	public void takeHit(Damager damager)
	{
		if (invulnerable)
			return;
		OnDie.Invoke(damager, this);
		if (disableOnDeath)
			gameObject.SetActive(false);
		if (destroyOnDeath)
			gameObject.SetActive(false);
	}

	public void makeInvulnerable()
	{
		invulnerable = true;
	}

	public void loseInvulnerable()
	{
		invulnerable = false;
	}
}
