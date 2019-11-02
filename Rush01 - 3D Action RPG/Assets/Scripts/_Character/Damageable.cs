using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Damageable : MonoBehaviour
{
	[System.Serializable]
	public class HealthEvent : UnityEvent<Damageable>
	{ }
	[System.Serializable]
	public class DamageEvent : UnityEvent<Damageable>
	{ }
	[System.Serializable]
	public class HealEvent : UnityEvent<int, Damageable>
	{ }
	[SerializeField] private HealthEvent OnHealthSet = null;
	[SerializeField] private DamageEvent OnTakeDamage = null;
	[SerializeField] private HealEvent OnGainHealth = null;
	[SerializeField] private DamageEvent OnDie = null;

	[SerializeField] private bool disableOnDeath = false;
	[SerializeField] private bool destroyOnDeath = false;
	[SerializeField] private bool invulnerable = false;
	[HideInInspector] public int currentHealth = 100;
	[HideInInspector] public int maxHealth = 100;

	private CharacterData data;

	private void OnEnable()
	{
		data = GetComponent<CharacterData>();
		currentHealth = data.maxHP;
		maxHealth = data.maxHP;
	}

	public void TakeDamage(int damage, int hitChance)
	{
		maxHealth = data.maxHP;
		if (invulnerable || currentHealth <= 0)
			return;

		hitChance -= data.agility;
		if (Random.Range(0, 100) > hitChance)
			return;

		damage = Mathf.RoundToInt(damage * (float)(1 - data.armor / 200));
		currentHealth -= damage;
		OnTakeDamage.Invoke(this);
		OnHealthSet.Invoke(this);

		if (currentHealth <= 0)
		{
			currentHealth = 0;
			OnDie.Invoke(this);
			if (disableOnDeath)
				gameObject.SetActive(false);
			if (destroyOnDeath)
				Destroy(gameObject);
		}
	}
	public void GainHealth(int amount)
	{
		currentHealth += amount;

		if (currentHealth > data.maxHP)
			currentHealth = data.maxHP;

		OnHealthSet.Invoke(this);
		OnGainHealth.Invoke(amount, this);
	}
	public void SetHealth(int amount)
	{
		currentHealth = amount;
		OnHealthSet.Invoke(this);
	}

	public void gainInvulnerability()
	{
		invulnerable = true;
	}

	public void loseInvulnerability()
	{
		invulnerable = false;
	}

	public void toggleInvulnerability()
	{
		invulnerable = invulnerable ? false : true;
	}
}
