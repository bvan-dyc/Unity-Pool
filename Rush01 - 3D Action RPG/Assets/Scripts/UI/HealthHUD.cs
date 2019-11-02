using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHUD : MonoBehaviour
{
	[SerializeField] private Damageable representedDamageable = null;
	[SerializeField] private Slider healthGauge = null;
	[SerializeField] private Text currentHealthText = null;
	[SerializeField] private Text maxHealthText = null;
    private void Start()
    {
		representedDamageable = GameObject.FindGameObjectWithTag("Player").GetComponent<Damageable>();
		RefreshValues();
	}

	public void RefreshValues()
	{
		healthGauge.maxValue = representedDamageable.maxHealth;
		healthGauge.value = representedDamageable.currentHealth;
		currentHealthText.text = representedDamageable.currentHealth.ToString();
		maxHealthText.text = representedDamageable.maxHealth.ToString();
	}
}
