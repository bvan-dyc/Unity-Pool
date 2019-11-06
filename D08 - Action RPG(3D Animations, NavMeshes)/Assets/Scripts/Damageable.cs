using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Damageable : MonoBehaviour
{
	[System.Serializable]
	public class DamageEvent : UnityEvent<Damageable>
	{ }
	[SerializeField] private bool disableOnDeath = false;
	[SerializeField] private bool destroyOnDeath = false;
	[SerializeField] private float onDeathDelay = 0;
	private int health = 100;
	[SerializeField] private DamageEvent OnDie = null;
	[SerializeField] private Slider healthSlider = null;
	[SerializeField] private Text healthText = null;
	[SerializeField] private Animator animator = null;
	[SerializeField] private bool debugHit = false;

	[SerializeField] private bool invulnerable = false;
	public bool dead = false;
	private CharacterData data;

	private void Start()
	{
		data = GetComponent<CharacterData>();
		health = data.hp;
		if (healthSlider)
		{
			healthSlider.maxValue = health;
			healthText.text = health + " / " + health;
		}
	}
	private void Update()
	{
		if (debugHit)
		{
			takeHit(5, 100);
			debugHit = false;
		}
	}
	public void takeHit(int damage, int hitChance)
	{
		if (invulnerable || dead)
			return;
		damage = Mathf.RoundToInt(damage * (float)(1 - data.armor / 200));
		hitChance -= data.agility;
		if (Random.Range(0, 100) > hitChance)
			return;
		health -= damage;
		if (healthSlider)
		{
			healthSlider.value = health;
			healthText.text = health + " / " + data.hp;
		}
		if (health <= 0)
		{
			dead = true;
			animator.SetTrigger("death");
			kill();
		}
	}

	public void kill()
	{
		OnDie.Invoke(this);
		if (disableOnDeath)
			gameObject.SetActive(false);
		if (destroyOnDeath)
			Destroy(gameObject);
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
